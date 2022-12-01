namespace bamms6practa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("открыть файл");
            string open = Console.ReadLine();
            List<Figure> figures = Converters.ReadData(open);
            string text = Editor.Open(figures);
            Converters.WriteData(Converters.OpenText(text), open);
            figures = Converters.ReadData(open);

            Console.Clear();
            Console.WriteLine("записать в файл");
            string write = Console.ReadLine();
            Converters.WriteData(figures, write);
        }
    }
}