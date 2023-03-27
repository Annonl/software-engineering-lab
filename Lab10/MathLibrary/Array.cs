namespace MathLibrary;
public class Array
{
    public static char[] Duplicate(int n, char[] array)
    {
        var result = new HashSet<char>();

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (array[i] == array[j])
                {
                    result.Add(array[i]);
                }
            }
        }

        return result.ToArray();
    }
}

