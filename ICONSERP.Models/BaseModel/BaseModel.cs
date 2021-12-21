using System.ComponentModel.DataAnnotations.Schema;



namespace ICONSERP.Models.BaseModel;


public class BaseModel
{ 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual Guid ID { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public Guid CreatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public Guid? UpdatedBy { get; set; }
    public DateTime? DeletedDate { get; set; }
    public Guid? DeletedBy { get; set; }
}

