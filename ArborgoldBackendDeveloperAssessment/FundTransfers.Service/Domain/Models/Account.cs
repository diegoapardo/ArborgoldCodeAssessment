using System.ComponentModel.DataAnnotations;

namespace FundTransfers.Service.Domain.Models;

public class Account
{
    [Key] public int Id { get; set; }
    public User User { get; set; }
    public decimal Balance { get; set; }
    public string Secret { get; set; }
    public DateTime Created { get; set; }
}