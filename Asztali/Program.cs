using Asztali.DataBase;
using Asztali.Model;
using System.Data;

internal class Program
{
    public static readonly string conncetionString = "Server=localhost;Database=11a_foldrajz;User=root;";
    public static DataBaseService dbservice = new DataBaseService();

    //adattarolo
    public static DataTable adatok = new DataTable();
    public static List<Konyvtar> lista = new List<Konyvtar>();

    private static void Main(string[] args)
    {
        Console.WriteLine("A GITHUB EGY SZAR!");
    }
}