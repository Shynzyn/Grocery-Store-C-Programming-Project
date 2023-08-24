namespace GroceryStore.Utils;

public static class Utility
{
    public static string CenterAlign(string text, int totalWidth)
    {
        var padding = totalWidth - text.Length;
        var leftPadding = padding / 2;
        return text.PadLeft(leftPadding + text.Length).PadRight(totalWidth);
    }
}