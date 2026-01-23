using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emploees.Domain
{
    public class CostItem : ITree<CostItem>, ISelfReferencingTree
    {
        [MaxLength(36)]
        public string? Id { get; set; }

        [MaxLength(36)]
        public string? ParentId { get; set; }

        [MaxLength(150)]
        public string? Name { get; set; }

        [NotMapped]
        public List<CostItem> Children { get; set; } = [];

        [NotMapped]
        public bool Expanded { get; set; }
    }
}
