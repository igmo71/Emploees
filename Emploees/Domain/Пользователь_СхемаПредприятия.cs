using System.ComponentModel.DataAnnotations;

namespace Emploees.Domain
{
    public class Пользователь_СхемаПредприятия
    {
        [MaxLength(AppSettings.GUID)] public string? Пользователь_Key { get; set; }

        public Catalog_Пользователи? Пользователь { get; set; }


        [MaxLength(AppSettings.GUID)] public string? СхемаПредприятия_Key { get; set; }

        public Catalog_СхемаПредприятия? СхемаПредприятия { get; set; }
    }
}
