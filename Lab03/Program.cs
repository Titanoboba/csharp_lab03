using System;
using System.Runtime.CompilerServices;

struct Vector
{
    public double x, y, z;

    public Vector(double x, double y, double z)
    {
        this.x = x; this.y = y; this.z = z;
    }

    public double VectorLength() { return (Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2))); }

    public static Vector operator +(Vector v1, Vector v2)
    {
        return (new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z));
    }

    public static Vector operator *(Vector v1, Vector v2)
    {
        return (new Vector(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z));
    }

    public static Vector operator *(Vector v1, int num)
    {
        return (new Vector(v1.x * num, v1.y * num, v1.z * num));
    }

    public static bool operator >(Vector v1, Vector v2)
    {
        if (v1.VectorLength() > v2.VectorLength()) { return true; }
        else { return false; }
    }

    public static bool operator <(Vector v1, Vector v2)
    {
        if (v1.VectorLength() < v2.VectorLength()) { return true; }
        else { return false; }
    }
}

interface IEquatable<T>
{
    bool Equals(T other);
}

public class Car : IEquatable<Car>
{
    public string name, engine;
    public int maxspeed;

    Car(string name, string engine, int maxspeed)
    {
        this.name = name;
        this.engine = engine;
        this.maxspeed = maxspeed;
    }

    public override string ToString() { return (this.name); }

    public bool Equals(Car? car)
    {
        return (this.name, this.engine, this.maxspeed) == (car?.name, car?.engine, car?.maxspeed);
    }
}

public class CarsCatalog
{
    private Car[] cars;

    CarsCatalog(Car[] cars) { this.cars = cars; }

    public string this[int i]
    {
        get
        {
            return ($"Name: {cars[i].name}, Engine {cars[i].engine}");
        }
    }
}

public class Currency
{
    private int value = 100;

    public virtual int Value
    {
        get { return this.value; }
        set { this.value = value; }
    }

}

public class CurrencyUSD : Currency
{
    private int course;

    public int Course
    {
        get { return this.course; }
        set { this.course = value; }
    }

    public override int Value
    { 
        get { return (base.Value * course); }
    }
}

public class CurrencyEUR : CurrencyUSD {}
public class CurrencyRUB : CurrencyUSD {}

internal class Program
{
    static void Main(string[] args)
    {
        CurrencyEUR euro = new CurrencyEUR();
        CurrencyRUB rub = new CurrencyRUB();
        CurrencyUSD usd = new CurrencyUSD();

        rub.Course = 1;

        Console.WriteLine("Input currency USD -> RUB (1 usd = ? rub)");
        usd.Course = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Input currency EUR -> RUB");
        euro.Course = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"100 Euro = {euro.Value} rubles\n100 Usd = {usd.Value} rubles\n100 Rubles = {rub.Value} rubles");
    }
}
