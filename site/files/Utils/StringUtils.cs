using System;

namespace Site.Utils
{
  public static class StringUtils
  {

    public static string PasswordGenerate() => Guid.NewGuid().ToString().Substring(0, 8);

    public static string HashGenerate() => Guid.NewGuid().ToString().Substring(0, 8);
  }
}