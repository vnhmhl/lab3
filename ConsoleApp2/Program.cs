using System;

class Program
{
    // Точное значение sin(x)
    static double TrueSin(double x)
    {
        return Math.Sin(x);
    }

    // Расчет суммы ряда с фиксированным числом слагаемых n
    static double SinTaylor_N(double x, int n)
    {
        double sum = 0;
        double term = x; // первый член
        int sign = 1;

        for (int i = 0; i <= n; i++)
        {
            int power = 2 * i + 1;
            double factorial = Factorial(power);
            term = Math.Pow(x, power) / factorial;
            sum += sign * term;
            sign *= -1;
        }

        return sum;
    }

    // Расчет суммы ряда по заданной точности epsilon
    static double SinTaylor_E(double x, double epsilon)
    {
        double sum = 0;
        double term = x;
        int i = 0;
        int sign = 1;

        while (Math.Abs(term) >= epsilon)
        {
            int power = 2 * i + 1;
            double factorial = Factorial(power);
            term = Math.Pow(x, power) / factorial;
            sum += sign * term;
            sign *= -1;
            i++;
        }

        return sum;
    }

    // Факториал
    static double Factorial(int n)
    {
        double result = 1;
        for (int i = 2; i <= n; i++)
            result *= i;
        return result;
    }

    static void Main()
    {
        double a = 0.1;
        double b = 1.0;
        int k = 10;
        int n = 10;
        double epsilon = 0.0001;

        double step = (b - a) / k;

        Console.WriteLine(" X\tSN (n=10)\tSE (eps=0.0001)\tY = sin(x)");
        Console.WriteLine("-----------------------------------------------");

        for (int i = 0; i <= k; i++)
        {
            double x = a + i * step;
            double sn = SinTaylor_N(x, n);
            double se = SinTaylor_E(x, epsilon);
            double y = TrueSin(x);

            Console.WriteLine($"{x:F4}\t{sn:F6}\t{se:F6}\t{y:F6}");
        }
    }
}
