using Asztali.DataBase;
using Asztali.Model;
using System.Data;

internal class Program
{
    public static readonly string conncetionString = "Server=localhost;Database=asztali_projekt;User=root;";
    public static DataBaseService dbservice = new DataBaseService();

    public static DataTable adatok = new DataTable();
    public static List<Konyvtar> lista = new List<Konyvtar>();

    private static void Main(string[] args)
    {
        DbCheck(conncetionString);
        SelectFromTable("konyvek", conncetionString);
        Adatbetoltes(ref adatok);

        Console.WriteLine("-------------------");
        Ketezertizenketto(lista);
        Console.WriteLine("--------------------");
        MennyikonyvOsszTrue(lista);
        Console.WriteLine("--------------------");
        Ezerkilencszazkilencvenkilenc(lista);
        Console.WriteLine("-------------------");
        OsszesKolcsonzott(lista);
        Console.WriteLine("-------------------");
        Konyvkereses(lista);




    }

    private static void Konyvkereses(List<Konyvtar> lista)
    {
        Console.WriteLine("Melyik év adatait szeretnéd látni? ");
        int be = Convert.ToInt32(Console.ReadLine());
        foreach (var item in lista)
        {
            if (item.Kiadasiev == be)
            {
                Console.WriteLine($"\t{item.Booknev}, {item.Kivaneveve}, {item.Kiadasiev}, {item.Kolcsonzesideje}, {item.ISBN}");
            }
        }
    }

    private static void OsszesKolcsonzott(List<Konyvtar> lista)
    {
        int db = 0;

        foreach (var item in lista)
        {

            db++;

        }

        Console.WriteLine($"Az összes kölcsönzött könyv: {db}");
    }

    private static void MennyikonyvOsszTrue(List<Konyvtar> lista)
    {
        int db = 0;
        foreach (Konyvtar item in lista)
        {
            if (item.Kivaneveve == "true")
            {
                db++;


            }

        }
        Console.WriteLine($"Kivett könyvek összesen: {db}");



    }
    private static void Ezerkilencszazkilencvenkilenc(List<Konyvtar> lista)
    {
        Console.WriteLine($"Könyvek, amik 1999 ben lettek kiadva:");
        foreach (var i in lista)
        {
            if (i.Kiadasiev == 1999)
            {
                Console.WriteLine($" \t{i.Booknev}");
            }
        }
    }

   

    private static void Ketezertizenketto(List<Konyvtar> lista)
    {
        Console.WriteLine("2012-ben kiadott könyvek: ");
        foreach (var item in lista)
        {
            if (item.Kiadasiev == 2012)
            {
                Console.WriteLine($" \t{item.Booknev}");
            }
        }
    }
    private static void Adatbetoltes(ref DataTable adatok)
    {
        foreach (DataRow o in adatok.Rows)
        {
            Konyvtar konyv = new Konyvtar();

            konyv.BookID = o.Field<int>(0);
            konyv.Booknev = o.Field<string>(1);
            konyv.Kivaneveve = o.Field<string>(2);
            konyv.Kiadasiev = o.Field<int>(3);
            konyv.Kolcsonzesideje = o.Field<string>(4);
            konyv.ISBN = o.Field<long>(5);

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




    