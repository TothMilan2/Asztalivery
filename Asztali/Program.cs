using Asztali.DataBase;
using Asztali.Model;
using System.Data;

internal class Program
{
    public static readonly string conncetionString = "Server=localhost;Database=asztali_projekt;User=root;";
    public static DataBaseService dbservice = new DataBaseService();

    //adattarolo
    public static DataTable adatok = new DataTable();
    public static List<Konyvtar> lista = new List<Konyvtar>();

    private static void Main(string[] args)
    {
        DbCheck(conncetionString);
        SelectFromTable("konyvek", conncetionString);
        Adatbetoltes(ref adatok);
        Console.WriteLine(lista.Count);

    }

    private static void Adatbetoltes(ref DataTable adatok)
    {
        foreach (DataRow o in adatok.Rows)
        {
            Konyvtar konyv=new Konyvtar();

            konyv.BookID = o.Field<int>(0);
            konyv.Booknev = o.Field<string>(1);
            konyv.Kivaneveve = o.Field<bool>(2);
            konyv.Kiadasiev = o.Field<string>(3);
            konyv.Kolcsonzesideje = o.Field<int>(4);
            konyv.ISBN = o.Field<int>(5);

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