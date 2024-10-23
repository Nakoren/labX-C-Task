using System.Reflection.Metadata.Ecma335;


internal class Program
{
    private static void Main(string[] args)
    {
        CustomList CL = new CustomList();
        CL.Add(3);
        int? test = CL.Get(1);
        Console.WriteLine(test);
    }
}

