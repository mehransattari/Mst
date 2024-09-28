namespace Mst;

public static class String
{
    public static string Fix(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return null;
        }

        text = text.Trim();

        // استفاده از Regex برای جایگزینی فضاهای اضافی به جای حلقه  
        text = System.Text.RegularExpressions.Regex.Replace(text, @"\s+", " ");

        return text;
    }
  
}