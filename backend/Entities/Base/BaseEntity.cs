namespace backend.Entities;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        CreatedAt ??= DateTime.Now;
        UpdatedAt = DateTime.Now;
        IsDeleted ??= false;
    }
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? CreatingUserId { get; set; }
    public int? UpdatingUserId { get; set; }
    public bool? IsDeleted { get; set; }
}
