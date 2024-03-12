using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Brand : BaseEntity<int>
{
    public string Name { get; set; }  //Audi 


    public ICollection<Model> Models { get; set; }

    public Brand()
    {
        Models = new HashSet<Model>();
    }

    public Brand(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
}
