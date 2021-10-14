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
            Console.WriteLine("\n4.feladat");
            // 4.feladat
            int evszam;
            do
            {
                Console.WriteLine("Adjon meg egy évszámot 1900 és 1999 között");
                evszam = int.Parse(Console.ReadLine());
            } while (1900 > evszam || evszam > 1999);

            foreach (var item in balkezeseklista)
            {
                if(item.elso.Year == evszam)
                {
                    Console.WriteLine($"{item.nev} {item.elso.Year}-{item.elso.Month}-{item.elso.Day} {item.utolso.Year}-{item.utolso.Month}-{item.utolso.Day} {item.magassag} inch {item.suly} pound");
                }

            }
            Console.WriteLine("\n5.feladat");
            // 5. feladat
            var legkorábbi = balkezeseklista.Min(v => v.elso.Year);
            Console.WriteLine($"A legkorábbi év:{legkorábbi}");
            Console.WriteLine("\n6.feladat");
            // 6. feladat
            bool kesobb = false;

            foreach (var item in balkezeseklista)
            {
                if (item.utolso.Year >= 2000 && !kesobb)
                {
                    kesobb = true;
                    break;
                }
            }
            if (!kesobb)
            {
                Console.WriteLine("Mindenki 2000 előtt lépett pályára");
            }
            else
            {
                Console.WriteLine("Nem mindenki 2000 előtt lépett pályára");
            }
            Console.WriteLine("\n7.feladat");
            //7. feladat
            List<string> John = new List<string>();
            foreach (var item in balkezeseklista)
            {
                if (item.nev.Contains("John"))
                {
                    John.Add(item.nev);
                }
            }
            Console.WriteLine($"{John.Count} darab John nevű versenyző van");
            foreach (var nev in John)
            {
                Console.WriteLine(nev);
            }
            Console.WriteLine("\n8.feladat");
            //8.feladat
            List<string> keresettNevek = new List<string> { "Joe", "John", "Jim", "Jack" };
            //string[] nevek = { };
            var nevek = balkezeseklista.GroupBy(v => v.nev.Split(' ')[0]);

            FileStream fs = new FileStream("kernevek.txt", FileMode.OpenOrCreate);
            StreamWriter iro = new StreamWriter(fs);

            foreach (var nev in nevek)
            {
                if (keresettNevek.Contains(nev.Key))
                {
                    Console.WriteLine($"{nev.Key} {nev.Count()}");
                    iro.WriteLine($"{nev.Key} {nev.Count()}");
                }
                
            }
            iro.Close();
            fs.Close();
                

            Console.ReadLine();
        }
    }
}
