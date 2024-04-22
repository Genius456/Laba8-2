using System;

interface IHexadecimalOperations
{
    void InputHexadecimal();
    void DisplayHexadecimal();
    void SubtractHexadecimal(Hexadec2 hex);
    void DivideHexadecimal(Hexadec2 hex);
}

abstract class HexadecBase
{
    protected string wholePart;
    protected string fractionalPart;

    public HexadecBase()
    {
        wholePart = "0";
        fractionalPart = "0";
    }

    ~HexadecBase()
    {
        Console.WriteLine("Object destroyed.");
    }
}

class Hexadec2 : HexadecBase, IHexadecimalOperations
{
    public void InputHexadecimal()
    {
        Console.Write("Введите целую часть в 16-ричной системе: ");
        string inputWholePart = Console.ReadLine();

        if (!IsHexadecimal(inputWholePart))
        {
            Console.WriteLine("Ошибка: введенное значение не является шестнадцатеричным числом.");
            return;
        }

        wholePart = inputWholePart;

        Console.Write("Введите дробную часть в 16-ричной системе: ");
        string inputFractionalPart = Console.ReadLine();

        if (!IsHexadecimal(inputFractionalPart))
        {
            Console.WriteLine("Ошибка: введенное значение не является шестнадцатеричным числом.");
            return;
        }

        fractionalPart = inputFractionalPart;
    }

    private bool IsHexadecimal(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsDigit(c) && !(c >= 'a' && c <= 'f') && !(c >= 'A' && c <= 'F'))
            {
                return false;
            }
        }
        return true;
    }

    public void DisplayHexadecimal()
    {
        Console.WriteLine($"Число: {wholePart}.{fractionalPart}");
    }

    public void SubtractHexadecimal(Hexadec2 hex)
    {
        int thisNumber = Convert.ToInt32(wholePart, 16);
        int thisNumber2 = Convert.ToInt32(fractionalPart, 16);
        int otherNumber = Convert.ToInt32(hex.wholePart, 16);
        int otherNumber2 = Convert.ToInt32(hex.fractionalPart, 16);
        int difference = thisNumber * 16 + thisNumber2 - (otherNumber * 16 + otherNumber2);

        Console.WriteLine($"Разность чисел: {Convert.ToString(difference, 16)}");
    }

    public void DivideHexadecimal(Hexadec2 hex)
    {
        int thisNumber = Convert.ToInt32(wholePart, 16);
        int thisNumber2 = Convert.ToInt32(fractionalPart, 16);
        int otherNumber = Convert.ToInt32(hex.wholePart, 16);
        int otherNumber2 = Convert.ToInt32(hex.fractionalPart, 16);

        if (otherNumber == 0 && otherNumber2 == 0)
        {
            Console.WriteLine("На ноль делить нельзя!");
            return;
        }

        double division = ((double)thisNumber * 16 + thisNumber2) / (otherNumber * 16 + otherNumber2);

        Console.WriteLine($"Частное чисел: {division}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Hexadec2 hex1 = new Hexadec2();
        Hexadec2 hex2 = new Hexadec2();

        Console.WriteLine("Введите первое число:");
        hex1.InputHexadecimal();

        Console.WriteLine("Введите второе число:");
        hex2.InputHexadecimal();

        Console.WriteLine("\nПервое число:");
        hex1.DisplayHexadecimal();

        Console.WriteLine("\nВторое число:");
        hex2.DisplayHexadecimal();

        Console.WriteLine("\nВычисляем разность чисел:");
        hex1.SubtractHexadecimal(hex2);

        Console.WriteLine("\nВычисляем частное чисел:");
        hex1.DivideHexadecimal(hex2);

        Console.ReadLine();
    }
}