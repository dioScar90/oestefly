using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities;

public abstract class BaseUser : BaseEntity
{
    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}
