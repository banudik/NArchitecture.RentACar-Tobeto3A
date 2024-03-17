using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories;

public class BaseEntity<TId>:IEntityTimeStamps
{
    public TId Id { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

    public BaseEntity()
    {

    }

    public BaseEntity(TId ıd, DateTime createdDate, DateTime updatedDate, DateTime deletedDate)
    {
        Id = ıd;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
        DeletedDate = deletedDate;
    }
}
