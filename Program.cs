Console.WriteLine("Калькулятор");
string comand = " ";
do
{
    Console.WriteLine("1.Сложение");
    Console.WriteLine("2.Вычитание");
    Console.WriteLine("3.Умножение");
    Console.WriteLine("4.Деление");
    Console.WriteLine("5.Возведение в степень");
    Console.WriteLine("6.Квадратный корень");
    Console.WriteLine("7.Нахождение 1%");
    Console.WriteLine("8.Факториал");
    Console.WriteLine("9.Выход из программы");
    Console.WriteLine("Введите номер программы, которую хотите выполнить: ");
    comand = Console.ReadLine();
    switch (comand)
    {
        case "1":
            Console.WriteLine("Введите первое число: ");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            double num2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Сумма равна: " + (num1 + num2));
            break;
        case "2":
            Console.WriteLine("Введите первое число: ");
            num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            num2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Разность равна: " + (num1 - num2));
            break;
        case "3":
            Console.WriteLine("Введите первое число: ");
            num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            num2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Произведение равно: " + num1 * num2);
            break;
        case "4":
            Console.WriteLine("Введите первое число: ");
            num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            num2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Частное равно: " + num1 / num2);
            break;
        case "5":
            Console.WriteLine("Введите число: ");
            num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите степень, в которую нужно возвести число: ");
            num2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(num1 + " в степени " + num2 + " равно " + Math.Pow(num1, num2));
            break;
        case "6":
            Console.WriteLine("Введите число: ");
            num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Корень из " + num1 + " равен " + Math.Sqrt(num1));
            break;
        case "7":
            Console.WriteLine("Введите число: ");
            num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("1% равен " + num1 / 100);
            break;
        case "8":
            Console.WriteLine("Введите число: ");
            num1 = Convert.ToDouble(Console.ReadLine());
            int i = 1;
            int res = 1;
            while (i <= num1)
            {
                res *= i;
                i++;
            }
            Console.WriteLine("Факториал " + num1 + " равен " + res);
            break;
        case "9":
            break;
    }
} while (comand != "9");