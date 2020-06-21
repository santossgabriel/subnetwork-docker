using System.Globalization;

namespace Site.Extentions
{
  public static class StringExtensions
  {
    public static string ToMoney(this decimal value) => string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", value);

    public static string FirstLetterToUpper(this string value)
    {
      if (!string.IsNullOrEmpty(value))
        return $"{value[0].ToString().ToUpper()}{value.Substring(1)}";
      return value;
    }
  }
}