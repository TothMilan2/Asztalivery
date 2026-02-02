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

        Ketezertizenketto(lista);
        MennyikonyvOsszTrue(lista);
        Ezerkilencszazkilencvenkilenc(lista);

        
    }

    private static void Ezerkilencszazkilencvenkilenc(List<Konyvtar> lista)
    {
        Console.WriteLine($"Könyvek, amik 1999 ben lettek kiadva:");
        foreach (var i in lista)
        {
            if(i.Kiadasiev == 1999)
            {
                Console.WriteLine(i.Booknev);
            }
        }
    }

    private static void MennyikonyvOsszTrue(List<Konyvtar> lista)
    {
        int db = 0;
        foreach (Konyvtar item in lista)
        {
            if (item.Kivaneveve == "true")
            {
                db++;
                Console.WriteLine($"Kivett könyvek összesen: {db}");
            }
        }
    }

        private static void Ketezertizenketto(List<Konyvtar> lista)
        {
            foreach (var item in lista)
            {
                if (item.Kiadasiev == 2012)
                {
                    Console.WriteLine(item.Booknev);
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