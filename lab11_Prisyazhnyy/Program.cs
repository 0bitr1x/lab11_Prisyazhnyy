//cборник задач/тема 11/базовый уровень/вариант 24
try
{
    Console.Write("Введите название: ");
    string name = Console.ReadLine()!;
    Console.Write("Введите мощность: ");
    double power = double.Parse(Console.ReadLine()!);
    Console.Write("Введите высоту(м): ");
    double height = double.Parse(Console.ReadLine()!);
    Console.Write("Введите коэффициент излучения: ");
    double emissivity = double.Parse(Console.ReadLine()!);

    Aerial aerial = new Aerial(name, power, height);

    Console.WriteLine("информации об объектах класса 1-го уровня:");
    Console.WriteLine($"Q = {aerial.Calc()}");
    aerial.Print();

    Console.WriteLine();
    BestAerial bestAerial = new BestAerial(name, power, height, emissivity);

    Console.WriteLine("информации об объектах класса 2-го уровня:");
    Console.WriteLine($"Q = {bestAerial.Calc()}");
    bestAerial.Print();
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
class Aerial
{
    protected string name;
    protected double power;
    protected double height;

    public Aerial(string name, double power, double height)
    {
        this.name = name;
        this.power = power;
        this.height = height;
    }
    public virtual double Calc()
    {
        return power + 0.5 * height;
    }
    public virtual void Print()
    {
        Console.WriteLine($"название: {name}, мощность: {power}, высоту(м): {height}");
    }
}
class BestAerial : Aerial
{
    protected double emissivity;
    public BestAerial(string name, double power, double height, double emissivity) : base(name, power, height)
    {
        this.emissivity = emissivity;
    }
    public override double Calc()
    {
        double baseCalc = base.Calc();
        return baseCalc - 0.1 * emissivity;
    }
    public override void Print()
    {
        base.Print();
        Console.WriteLine($"коэффициент излучения: {emissivity}");
    }
}