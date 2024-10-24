using System.Reflection.Metadata.Ecma335;


internal class Program
{
    private static void Main(string[] args)
    {
        CustomList<int> CL = new CustomList<int>();
        CL.Add(3);
        CL.Add(4);
        CL.Add(5);
        CL.Add(8);
        int? test = CL.Get(1);
        int checkFind = CL.Find((int n) =>
        {
            if (n>5)
            {
                return true;
            }
            else
            {
                return false;
            }
        });
        Console.WriteLine(checkFind);
        Console.WriteLine(CL.ToString());
        CL.Sort((int n1,int n2) =>
        {
            if (n1 < n2)
            {
                return 1;
            }
            if (n1 > n2)
            {
                return -1;
            }
            return 0;
        });
        Console.WriteLine(CL.ToString());
        Console.WriteLine(CL.IndexOf(4));
        Console.WriteLine(CL.IndexOf(10));
    }

    public int ReversedIntCompare(int n1, int n2)
    {
        if (n1 < n2)
        {
            return 1;
        }
        if (n1 > n2)
        {
            return -1;
        }
        return 0;
    }

}

