using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Balkezesek
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] sorok = File.ReadAllLines("balkezesek.csv").Skip(1).ToArray();
            List<Adatok> balkezeseklista = new List<Adatok>();
            //1. feladat: hány versenyzőről van adatunk?
            //var szamlalo = 0;
            /*foreach (var sor in sorok)
            {
                Adatok uj_adat = new Adatok(sor);
                balkezeseklista.Add(uj_adat);
            }*/
            for (int i = 1; i < sorok.Length; i++)
            {
                //szamlalo++;
                Adatok balkezesek = new Adatok(sorok[i]);
                balkezeseklista.Add(balkezesek);
            }
 
            //int s = sorok.Length - 1;
            //int N = sorok.Count ()-1;
            
            Console.WriteLine($"1. Feladat:{balkezeseklista.Count} versenyzőről van adatunk.");
            //2.feladat: kik azok a versenyzők, akik 1980-ban léptek először pályára?
            Console.WriteLine("2. feladat:");
            DateTime start = new DateTime(1980, 01, 01);
            DateTime end = new DateTime(1980, 12, 31);

            foreach (var balkezesek in balkezeseklista)

                if (balkezesek.elso >= start && balkezesek.elso <= end)
                   
                    Console.WriteLine(balkezesek.nev);
                   
                

            //3.feladat: kérjünk be egy nevet
            Console.WriteLine("3. feladat");
            Console.Write("Adjon meg egy nevet:");
            string a = Convert.ToString(Console.ReadLine());

            //string keresett = ;
            int c = 0;
            foreach (var nevek in balkezeseklista)
            //while(a != nevek.nev )
                 if (a == sorok[0])
                 
                     Console.Write("van");
                 
                 else
                 
                     Console.Write("hibás adat");
                 
                
                Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}
