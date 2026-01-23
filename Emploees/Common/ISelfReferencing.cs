using System.ComponentModel.DataAnnotations;

namespace Emploees.Common
{
    public interface ISelfReferencingTree
    {
        public string? Id { get; set; }
        public string? ParentId { get; set; }
        public string? Name { get; set; }
    }

    public interface ISelfReferencingCatalogTree
    {
        public string? Ref_Key { get; set; }
        public string? Parent_Key { get; set; }
        public string? Description { get; set; }
    }
}
