using DAL.Entities;

namespace DAL.Specifications;

public class TagByNameSpecification : Specification<Tag>
{
    public TagByNameSpecification(string name) : base(tag => tag.Name == name)
    {
    }
}
