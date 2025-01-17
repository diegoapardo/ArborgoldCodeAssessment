using System.ComponentModel.DataAnnotations;

namespace Reporting.Service.Domain.Models;
public class User
{
    public static User UserFactory (string name)
    {
        return new User { Name = name };
    }

    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}