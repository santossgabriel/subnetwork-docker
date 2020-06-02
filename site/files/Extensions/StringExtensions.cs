using System.Globalization;

namespace Site.Extentions
{
  public static class StringExtensions
  {
    public static string ToMoney(this decimal value)
    {
      var val = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", value);
      return val;
    }
  }
}