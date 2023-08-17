namespace GroceryStore.Utils
{
    public static class Utility
    {
        public static string CenterAlign(string text, int totalWidth)
        {
            int padding = totalWidth - text.Length;
            int leftPadding = padding / 2;
            return text.PadLeft(leftPadding + text.Length).PadRight(totalWidth);
        }
    }
}
