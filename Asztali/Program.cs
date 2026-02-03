using Asztali.DataBase;
using Asztali.Model;
using System.Data;
using System.Reflection.PortableExecutable;

internal class Program
{
    public static readonly string conncetionString = "Server=localhost;Database=asztali_projekt;User=root;";
    public static DataBaseService dbservice = new DataBaseService();

    public static FileReadDLL.ReadFromFile reader = new FileReadDLL.ReadFromFile();
    public static DataTable adatok = new DataTable();
    public static List<List<string>> adatok2= new List<List<string>>();
    public static List<Konyvtar> lista = new List<Konyvtar>();
    public static List<siker> lista2 = new List<siker>();


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
        Sikerbeolvasas(ref adatok2);
        Sikerbetoltes(adatok2);
        Console.WriteLine(lista2.Count);

    }

    private static void Sikerbetoltes(List<List<string>> adatok2)
    {

        
        foreach (var item in adatok2)
        {
            siker o = new siker();

            o.Konyvnev = item[0];
   

            
            lista2.Add(o);


        }
    }

    private static void Sikerbeolvasas(ref List<List<string>> adatok2)
    {

   
            adatok2 = reader.FileRead("2001.csv", 1, ';', false);
        

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




    