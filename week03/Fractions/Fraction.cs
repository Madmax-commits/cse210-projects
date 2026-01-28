public class Fraction
{
    // Private attributes (encapsulation)
    private int _top;
    private int _bottom;

    // Constructor: no parameters → 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor: one parameter → top/1
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor: two parameters → top/bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getter and Setter for top
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    // Getter and Setter for bottom
    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Returns fraction as a string (e.g., 3/4)
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Returns decimal value (e.g., 0.75)
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}
