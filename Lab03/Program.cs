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
    public double value { get; set; }

    public Currency(double _value)
    {
        value = _value;
    }

}

public class CurrencyUSD : Currency
{
    public CurrencyUSD(double value) : base(value) { }

    public static implicit operator CurrencyRUB(CurrencyUSD cusd)
    {
        return new CurrencyRUB(cusd.value * 202);
    }

    public static implicit operator CurrencyEUR(CurrencyUSD cusd)
    {
        return new CurrencyEUR(cusd.value * 382);
    }

}

public class CurrencyEUR : Currency 
{
    public CurrencyEUR(double value) : base(value) { }

    public static implicit operator CurrencyRUB(CurrencyEUR ceur)
    {
        return new CurrencyRUB(ceur.value / 382);
    }

    public static implicit operator CurrencyUSD(CurrencyEUR cusd)
    {
        return new CurrencyUSD(cusd.value * 2);
    }
}
public class CurrencyRUB : Currency 
{
    public CurrencyRUB(double value) : base(value) { }

    public static implicit operator CurrencyUSD(CurrencyRUB crub)
    {
        return new CurrencyUSD(crub.value * 202);
    }

    public static implicit operator CurrencyEUR(CurrencyRUB crub)
    {
        return new CurrencyEUR(crub.value * 382);
    }
}
