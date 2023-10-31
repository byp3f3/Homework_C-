using System.Timers;
internal class Program
{
    private static void Main(string[] args)
    {
        string program = " ";
        while (program != "4")
        {
            Console.WriteLine("Выберите программу, которую хотите запустить");
            Console.WriteLine("1.Угадай число");
            Console.WriteLine("2.Таблица умножения");
            Console.WriteLine("3.Вывод делителей числа");
            Console.WriteLine("4.Выход из программы");
            program = Console.ReadLine();
            switch (program)
            {
                case "1":
                    GuessNumber(); break;
                case "2":
                    MultiTable(); break;
                case "3":
                    Divider(); break;
                case "4": break;
            }
            static void GuessNumber()
            {
                Random rnd = new Random();
                int a = rnd.Next(0, 100);
                int b = 0;
                Console.WriteLine("Введите число:");
                do
                {
                    b = Convert.ToInt32(Console.ReadLine());
                    if (b < a) { Console.WriteLine("Нужно больше"); }
                    else if (b > a) { Console.WriteLine("Нужно меньше"); }
                } while (b != a);
                Console.WriteLine("Угадал!");
                return;
            }
            static void MultiTable()
            {
                int[,] Table = new int[10, 10];
                for (int m = 1; m < 10; m++)
                {
                    for (int n = 1; n < 10; n++)
                    { Table[m, n] = m * n ; }
                }

                for (int m = 1; m < 10; m++)
                {
                    for (int n = 1; n < 10; n++)
                    { Console.Write(Table[m, n] + "\t"); }
                    Console.WriteLine();
                }
                return;
            }
            static void Divider()
            {
                List<int> dividers = new List<int>();
                Console.WriteLine("Введите число");
                int num = Convert.ToInt32(Console.ReadLine());  
                for (int i =1; i<=num; i++)
                {
                    if (num % i == 0) 
                    { 
                        dividers.Add(i);
                        Console.Write(i + "\t"); }
                }
                Console.WriteLine();
                return;
            }
        }
    }
}