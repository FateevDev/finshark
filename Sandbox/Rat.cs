namespace Sandbox;

public class Rat
{
    private const float RadioactiveMaxRatAge = 0.5f;
    private const string DefaultColor = "grey";
    protected virtual int MaxRatAge => 20;

    public string Name { get; set; }
    public string Color { get; set; }

    public int Age
    {
        get => _age;
        set => _age = value > MaxRatAge ? MaxRatAge : value;
    }
    public bool IsRadioactive { get; set; }
    private int _age;

    public Rat() : this("Unknown", 0, null, null)
    {
    }

    public Rat(string name, int age, string? color, bool? isRadioactive)
    {
        Name = name;
        Age = age;
        Color = color ?? DefaultColor;
        IsRadioactive = isRadioactive ?? false;
    }

    public float TimeToLive()
    {
        return MaxRatAge - (IsRadioactive ? Age * RadioactiveMaxRatAge : Age);
    }

    public string Nickname() => $"The {Name} {Color}";
}

public class BigRat : Rat
{
    protected override int MaxRatAge => 100;

    public BigRat(string name, int age, string? color, bool? isRadioactive)
        : base(name, age, color, isRadioactive)
    {
    }
}