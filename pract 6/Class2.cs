using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace bamms6practa
{
    public class Converters
    {
        private static string GetExtension(string name)
        {
            return Path.GetExtension(name).ToLower();
        }
        public static List<Figure> ReadData(string file)
        {
            List<Figure> figures = new List<Figure>();
            string extension = GetExtension(file);
            string text = File.ReadAllText(file);
            switch (extension)
            {
                case ".json":
                    figures = OpenJson(text);
                    break;
                case ".xml":
                    figures = OpenXml(text);
                    break;
                case ".txt":
                    figures = OpenText(text);
                    break;
            }
            return figures;
        }
        public static List<Figure> OpenJson(string text)
        {
            List<Figure> figures = new List<Figure>();
            figures = JsonConvert.DeserializeObject<List<Figure>>(text);
            return figures;
        }
        public static List<Figure> OpenXml(string text)
        {
            File.WriteAllText("oks.xml", text);
            XmlSerializer xml = new XmlSerializer(typeof(List<Figure>));
            using (FileStream fs = new FileStream("oks.xml", FileMode.Open))
            {
                return (List<Figure>)xml.Deserialize(fs);
            }
        }
        public static List<Figure> OpenText(string text)
        {
            List<Figure> figures = new List<Figure>();
            string[] lines = text.Split("\n");
            for (int i = 0; i < lines.Count(); i += 3)
            {
                if (!(i + 2 > lines.Count()))
                {
                    Figure figure = new Figure(lines[i], Convert.ToInt32(lines[i + 1]), Convert.ToInt32(lines[i + 2]));
                    figures.Add(figure);
                }
                else break;
            }
            return figures;
        }
        public static string GetText(List<Figure> data)
        {
            string[] lines = new string[data.Count];
            for (int i = 0; i < data.Count; i++)
            {
                Figure figure = data[i];
                lines[i] = $"{figure.name}\n{figure.width}\n{figure.height}";
            }
            string text = String.Join("\n", lines);
            return text;
        }
        public static void WriteData(List<Figure> data, string path)
        {
            string extension = GetExtension(path);
            switch (extension)
            {
                case ".json":
                    string serialized;
                    serialized = JsonConvert.SerializeObject(data);
                    File.WriteAllText(path, serialized);
                    break;
                case ".xml":
                    XmlSerializer xml = new XmlSerializer(typeof(List<Figure>));
                    using (FileStream fs = new FileStream(path, FileMode.Open))
                    {
                        xml.Serialize(fs, data);
                    }
                    break;
                case ".txt":
                    string[] lines = new string[data.Count];
                    for (int i = 0; i < data.Count; i++)
                    {
                        Figure figure = data[i];
                        lines[i] = $"{figure.name}\n{figure.width}\n{figure.height}";
                    }
                    File.WriteAllLines(path, lines);
                    break;
            }
        }
    }
}
