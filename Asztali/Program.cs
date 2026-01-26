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
        Console.WriteLine("Professional munka zajlik...");

    }
    private static void Adatbetoltes(DataTable adatok)
    {
        foreach (DataRow o in adatok.Rows)
        {
            Konyvtar konyv = new Konyvtar();

            

            lista.Add(konyv);
        }
    }

    private static void SelectFromTable(string tableName, string conncetionString)
    {
        adatok = DataBaseService.GetAllData(tableName, conncetionString);
        Console.WriteLine("Adatok sikeresen szinkronizálva!");
    }

    private static void DbCheck(string conncetionString)
    {
        DataBaseService.DbConnectionCheck(conncetionString);
    }
}