using System.ComponentModel.DataAnnotations;

namespace Emploees.Domain
{
    public class AdUser
    {
        [MaxLength(AppSettings.SID)] public required string Sid { get; set; }
        [MaxLength(AppSettings.NAME)] public string? Name { get; set; }
        [MaxLength(AppSettings.NAME)] public string? Login { get; set; }
        [MaxLength(AppSettings.NAME)] public string? Title { get; set; }
        [MaxLength(AppSettings.NAME)] public string? Department { get; set; }
        [MaxLength(AppSettings.SID)] public string? Manager { get; set; }
        [MaxLength(AppSettings.DESCRIPTION)] public string? DistinguishedName { get; set; }
        public bool Enabled { get; set; }

        //[MaxLength(AppSettings.NAME)] public string? OU { get; set; }

        //[MaxLength(AppSettings.GUID)] public string? CatalogUserKey { get; set; }
        //[MaxLength(AppSettings.GUID)] public string? CatalogDivisionKey { get; set; }
        //[MaxLength(AppSettings.GUID)] public string? CatalogWarehouseKey { get; set; }
    }
}
