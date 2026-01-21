using System.ComponentModel.DataAnnotations;

namespace Emploees.Domain
{
    public class JobTitle
    {
        [MaxLength(36)]
        public required string Id { get; set; }

        [MaxLength(150)]
        public string? Name { get; set; }
    }
}
