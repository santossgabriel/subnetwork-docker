using Site.Extentions;

namespace Site.Models
{
  public class SimulationInstallmentModel
  {
    public int Number { get; set; }

    public decimal Cost { get; set; }

    public decimal Interest { get; set; }

    public decimal Total => Cost + Interest;

    public string CostMoney => Cost.ToMoney();

    public string InterestMoney => Cost.ToMoney();

    public string TotalMoney => Cost.ToMoney();
  }
}