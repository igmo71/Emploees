using System.ComponentModel.DataAnnotations;

namespace Emploees.Domain
{
    public class JobTitle
    {
        [MaxLength(36)]
        public string? Id { get; set; }

        [MaxLength(150)]
        public string? Name { get; set; }
    }
}
