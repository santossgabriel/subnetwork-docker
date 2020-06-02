using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Site.Extentions;

namespace Site.Models
{
  public class SimulationModel : BaseEntity
  {
    [Required]
    public string Description { get; set; }

    [Required]
    public string Email { get; set; }

    [Required, Range(12, 36)]
    public int Plots { get; set; }

    [Required, Range(1000, 1000000)]
    public decimal Amount { get; set; }

    public int UserId { get; set; }

    public List<SimulationInstallmentModel> Installments { get; set; }

    public decimal Total => Installments?.Sum(p => p.Total) ?? 0;

    public string TotalMoney => Total.ToMoney();

    public string AmountMoney => Amount.ToMoney();

    public override string EntityName => "SIMULATION";
  }
}