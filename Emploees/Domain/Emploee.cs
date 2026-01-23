using Emploees.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emploees.Domain
{
    public class Emploee
    {
        public Guid Id { get; set; }
        [MaxLength(150)] public string? Name { get; set; }

        [MaxLength(36)] public string? JobTitleId { get; set; }
        public JobTitle? JobTitle { get; set; }

        [MaxLength(36)] public string? CostItemId { get; set; }
        public CostItem? CostItem { get; set; }

        [MaxLength(36)] public string? DepartmentId { get; set; }
        public Catalog_СхемаПредприятия? Department { get; set; }

        [MaxLength(36)] public string? CityId { get; set; }
        public City? City { get; set; }

        [MaxLength(36)] public string? LocationId { get; set; }
        public Location? Location { get; set; }

        [MaxLength(36)] public string? UserUtId { get; set; }
        public Catalog_Пользователи? UserUt { get; set; }

        [MaxLength(AppSettings.SID)] public string? UserAdId { get; set; }
        public AdUser? UserAd { get; set; }

        [MaxLength(36)] public string? EmploeeBuhId { get; set; }
        public Catalog_Сотрудники_Buh? EmploeeBuh { get; set; }

        [MaxLength(36)] public string? EmploeeZupId { get; set; }
        public Catalog_Сотрудники_Zup? EmploeeZup { get; set; }

        [MaxLength(36)] public Guid? OperationManagerId { get; set; }
        public Emploee? OperationManager { get; set; }

        [MaxLength(36)] public Guid? LocationManagerId { get; set; }
        public Emploee? LocationManager { get; set; }
    }
}
