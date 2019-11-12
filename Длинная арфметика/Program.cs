using System;
using System.Numerics;
using System.IO;


namespace Длинная_арфметика
{
    class Program
    {
        static bool CorrectEntry(string number)
        {
            if (number == null)
                return false;
            string numerics = "0123456789";
            for (int i = 0; i < number.Length; i++)
            {
                bool flag = false;
                for (int k = 0; k < numerics.Length; k++)
                {
                    if (number[i] == numerics[k])
                        flag = true;
                }
                if (flag == false)
                {
                    
                    return false;
                }

            }
            return true;
        }
        static void Main(string[] args)
        {
            //LongArifmetik f, d;
            LongArifmetik first = null, second = null;
            do
            {
                Console.Write("Выберите откуда будут считаны числа:\n" +
                "1. Считать из файла.\n" +
                "2. Считать с клавиатуры.\n" +
                "Ваш выбор: ");
                
                string yourChoice;
                while (true)
                {
                    yourChoice = Console.ReadLine();
                    if (yourChoice == "1" || yourChoice == "2")
                        break;
                    else
                        Console.WriteLine("Неправильно сделан выбор. Повторите попытку.");
                }
                switch (yourChoice)
                {
                    case "1":
                        Console.Write("В файле должны находиться два числа, каждое с новой строки.Первое число на первой строке.\n" +
                            "Уккажите адрес файла: ");
                        string FilePath;
                        do
                        {
                            FilePath = @Console.ReadLine();
                            if (!File.Exists(FilePath))
                            {
                                Console.WriteLine("Указанный файл не существует.\nПовторите ввод.");

                            }
                        } while (!File.Exists(FilePath));

                        string x;

                        do
                        {
                            Console.WriteLine("Нажмите Enter для продолжения.");
                            while (Console.ReadKey().Key != ConsoleKey.Enter) ;
                            var reader = new StreamReader(FilePath);
                            x = reader.ReadLine();
                            
                            if (CorrectEntry(x))
                            {
                                first = LongArifmetik.Parse(x);
                            }
                            else
                            {
                                Console.WriteLine("Некорекктный ввод числа.");
                                reader.Dispose();
                                reader.Close();
                                continue;
                            }





                            x = reader.ReadLine();
                            if (CorrectEntry(x))
                            {
                                second = LongArifmetik.Parse(x);
                            }
                            else Console.WriteLine("Исправьте числа в файле.");
                            reader.Dispose();
                            reader.Close();
                        } while (!CorrectEntry(x));
                        break;
                    case "2":



                        do
                        {
                            Console.WriteLine("Введите первое число: ");
                            x = Console.ReadLine();
                            if (CorrectEntry(x))
                            {
                                first = LongArifmetik.Parse(x);
                            }
                            else Console.WriteLine("Некорекктный ввод числа." + " Повторите попытку ввода.");
                        } while (!CorrectEntry(x));
                        do
                        {
                            Console.WriteLine("Введите второе число: ");
                            x = Console.ReadLine();
                            if (CorrectEntry(x))
                            {
                                second = LongArifmetik.Parse(x);
                            }
                            else Console.WriteLine("Некоректный ввод числа." + " Повторите попытку ввода.");
                        } while (!CorrectEntry(x));
                        break;

                    default:
                        Console.WriteLine("Неправильно сделан выбор. Повторите попытку.");
                        break;
                }
                LongArifmetik sum = first + second, multi = first * second;
                Console.WriteLine("Результатожения:\n\t" + sum );
                Console.WriteLine("\nРезультат вычитания:\n\t");
                LongArifmetik subtract = first - second;
                Console.WriteLine(subtract); 
                Console.WriteLine("\nРезультат умножения:\n\t" + multi);
                Console.WriteLine("\nРезультат деления:\n\t");
                LongArifmetik div = first / second;
                Console.WriteLine(div);
                

                var writer = new StreamWriter(@"D:\result.txt");
                writer.WriteLine("Результат сложения:\n\t" + sum);
                writer.Write("\nРезультат вычитания:\n\t");
                writer.WriteLine(subtract);
                writer.WriteLine("\nРезультат умножения:\n\t" + multi);
                writer.Write("\nРезультат деления:\n\t");
                writer.WriteLine(div);
                
                

                Console.Write("Если хотите посмотреть время за которое выполняются операции нажмите v.\nВвод: ");
                if (Console.ReadLine() == "v")
                {
                    LongArifmetik.Statistic(first, second);
                    
                }
                Console.Write("Показать результат возведения в степень. Нажмите v.\nВвод: ");
                if (Console.ReadLine() == "v")
                {
                    LongArifmetik pow = LongArifmetik.FastPow(first, second);
                    Console.WriteLine("\nРезультат возведения в степень:\n\t" + pow);
                    writer.WriteLine("\nРезультат возведения в степень:\n\t" + pow);
                }
                writer.Dispose();
                writer.Close();
                Console.Write("Если хотите посмотреть время за которое выполняется операция возведения в степень нажмите v.\nВвод: ");
                if (Console.ReadLine() == "v")
                {
                    
                    LongArifmetik.StatisticPower(first, second);
                }

                Console.WriteLine("Для выхода нажмите Esc.");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            
        }
    }
}
