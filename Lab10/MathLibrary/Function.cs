namespace MathLibrary;

public static class Function
{
    public static Dictionary<double, double> GetTable(double dx, double xmin, double xmax, double a, double b)
    {
        if (xmin >= xmax)
        {
            return new Dictionary<double, double>();
        }

        if (dx <= 0)
        {
            return new Dictionary<double, double>();
        }

        var result = new Dictionary<double, double>();

        for (var i = xmin; i <= xmax; i += dx)
        {
            result.Add(i, Math.Round(Func10(i, a, b), 2));
        }

        return result;
    }

    public static double Func10(double x, double a, double b)
    {
        if (b == 0)
        {
            return double.NaN;
        }

        if (x == 0)
        {
            return double.NaN;
        }

        var temp = Math.Abs(Math.Pow(2 * a - 7.5 * x, 3));

        var temp2 = Math.Exp(2 * b / x - a / 2 * b);

        return temp + temp2;
    }
}
