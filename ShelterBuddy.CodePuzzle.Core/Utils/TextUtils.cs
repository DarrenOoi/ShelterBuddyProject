class TextUtils {
    public static string Pluralize(int value, string unit)
    {
        if (value == 1) 
        {
            return $"{value} {unit}";
        }

        return $"{value} {unit}s";
    }
}