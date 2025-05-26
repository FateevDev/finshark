namespace Sandbox;

public class Rat
{
    private const float RadioactiveMaxRatAge = 0.5f;
    protected virtual int MaxRatAge => 20;

    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public int Age { get; set; }
    public bool IsRadioactive { get; set; }

    public float TimeToLive()
    {
        return MaxRatAge - (IsRadioactive ? Age * RadioactiveMaxRatAge : Age);
    }
    
    public string Nickname() => $"The {Name} {Color}";
}

public class BigRat : Rat
{
    protected override int MaxRatAge => 100;
}
