using System;
using System.Text;

public class Product
{
    // Поля базового класу
    private string name;   // Назва товару
    private int quantity;  // Кількість товару
    private double price;  // Ціна за одиницю

    // Конструктор базового класу
    public Product(string name, int quantity, double price)
    {
        this.name = name;
        this.quantity = quantity;
        this.price = price;
    }

    // Метод для обчислення загальної вартості товару
    public virtual double CalculateTotalCost()
    {
        return quantity * price;
    }

    // Метод для виведення інформації про товар
    public string DisplayInformation()
    {
        return $"Назва: {name}, Кількість: {quantity}, Ціна за одиницю: {price}, Загальна вартість: {CalculateTotalCost()}";
    }
}

public class SortedProduct : Product
{
    // Поле для сорту
    private double sort;

    // Конструктор похідного класу
    public SortedProduct(string name, int quantity, double price, double sort)
        : base(name, quantity, price)
    {
        this.sort = sort;
    }

    // Перевизначений метод для обчислення загальної вартості з урахуванням сорту
    public override double CalculateTotalCost()
    {
        return base.CalculateTotalCost() * sort;  // Загальна вартість з урахуванням сорту
    }

    // Метод для виведення інформації про сортовий товар
    public new string DisplayInformation()
    {
        return base.DisplayInformation() + $", Сорт: {sort}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Встановлюємо кодування для коректного відображення українських символів
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.WriteLine("Введіть інформацію про товар:");

        // Введення назви товару
        Console.Write("Назва: ");
        string name = Console.ReadLine();

        // Введення кількості товару
        Console.Write("Кількість: ");
        int quantity = int.Parse(Console.ReadLine());

        // Введення ціни за одиницю товару
        Console.Write("Ціна за одиницю: ");
        double price = double.Parse(Console.ReadLine());

        // Введення сорту
        Console.Write("Сорт (s): ");
        double sort = double.Parse(Console.ReadLine());

        // Створення об'єкта похідного класу
        SortedProduct sortedProduct = new SortedProduct(name, quantity, price, sort);

        // Виведення інформації про товар
        Console.WriteLine(sortedProduct.DisplayInformation());

        // Затримка для перегляду результатів
        Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
        Console.ReadKey();
    }
}
