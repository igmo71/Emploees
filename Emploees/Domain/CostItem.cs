using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Emploees.Domain
{
    public class CostItem : ITree<CostItem>
    {
        [MaxLength(36)]
        public required string Id { get; set; }

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
