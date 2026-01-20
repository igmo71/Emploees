using System.ComponentModel.DataAnnotations;

namespace Emploees.Domain
{
    public class Catalog_СхемаПредприятия
    {
        [MaxLength(AppSettings.GUID)] public required string Ref_Key { get; set; }
        [MaxLength(AppSettings.GUID)] public string? Parent_Key { get; set; }
        [MaxLength(AppSettings.DESCRIPTION)] public string? Description { get; set; }
        public bool DeletionMark { get; set; }
    }
}
