using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PR
{
    internal class Program
    {
        public static void Error(string message, ConsoleColor cc)
        {
            Console.ForegroundColor = cc;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                string filepath;
                int n = 0;
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("Здравствуйте\nПрактическая работа номер 16");
                Console.Write("Введите Y чтобы продолжить или N чтобы выйти ");
                string select_key = Console.ReadLine();
                switch (select_key)
                {
                    case "Y":
                        Console.WriteLine("Введите путь к сохраненному файлу, например: D:\\Users\\1213-12\\Documents\\2-ИСП\\PR16.txt");
                        filepath = Console.ReadLine(); 
                        try
                        {
                            FileStream F = new FileStream(filepath, FileMode.Create);
                            StreamWriter writer = new StreamWriter(F);
                            Console.Write("Введите кол-во чисел, n= ");
                            n=Convert.ToInt32(Console.ReadLine());
                            int[] array = new int[n];
                            Random rnd = new Random();
                            for (int i = 0; i < n; i++)
                            {
                                array[i] = rnd.Next(-10, 15);
                            }
                            for (int i = 0; i < n; i++) 
                            { 
                                writer.Write(array[i]); 
                                Console.WriteLine(array[i]);
                            }
                            writer.Close();
                        }
                        catch (Exception e) { Error(e.Message, ConsoleColor.Red); }
                        int[] mas = null;
                        string s;
                        try
                        {
                            Array.Resize(ref mas, n);
                            Console.WriteLine("Содержимое файла {0}: ", filepath);
                            FileStream F1 = new FileStream(filepath, FileMode.Open);
                            StreamReader reader = new StreamReader(F1);
                            while ((s = reader.ReadLine()) != null)
                            {
                                s = s.TrimEnd(' ');
                                string[] text = s.Split(' ');
                                for (int j = 0; j < text.Length; j++)
                                {
                                    mas[j] = Convert.ToInt32(text[j]);
                                }
                            }F1.Close();
                        }
                        catch (IOException i) { Error(i.Message, ConsoleColor.Red); }
                        catch (FormatException f) { Error(f.Message, ConsoleColor.Red); }
                        catch (Exception e) { Error(e.Message, ConsoleColor.Red); }
                        foreach(int ELEMENT  in mas)
                        {
                            Console.WriteLine(ELEMENT);
                        }
                        Console.ReadKey();
                        break;
                    case "N":
                        Console.WriteLine("До свидания");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
