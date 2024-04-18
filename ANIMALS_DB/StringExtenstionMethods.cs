namespace ANIMALS_DB;

public static class StringExtenstionMethods
{
    public static string getSqlOrderBy(this string parametr)
    {
        string properCaseString = char.ToUpper(parametr[0]) + parametr.Substring(1).ToLower();
        return properCaseString;
    }
}