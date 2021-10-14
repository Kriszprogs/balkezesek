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
            List<Adatok> nyolcvan = new List<Adatok>();
            DateTime start = new DateTime(1980, 01, 01);
            DateTime end = new DateTime(1980, 12, 31);

            foreach (var item in balkezeseklista)

                if (item.elso.Year == 1980)
                {
                    Console.WriteLine(item.nev);
                    nyolcvan.Add(item);
                }
                    //(balkezesek.elso >= start && balkezesek.elso <= end)
                   
                    //Console.WriteLine(balkezesek.nev);
                   
                

            //3.feladat: kérjünk be egy nevet
            Console.WriteLine("3. feladat");
            Console.Write("Adjon meg egy nevet:");
            string a = Console.ReadLine();

            int index = nyolcvan.FindIndex(v => v.nev == a);

            if (index >= 0)
            {
                double magassag = Convert.ToDouble(nyolcvan[index].magassag * 2.54);
                Console.WriteLine($"{Math.Round(magassag, 1)} cm");
            }
            else
            {
                Console.WriteLine("Hibás adat");
            }
            
            Console.ReadLine();
        }
    }
}
