using System.ComponentModel.DataAnnotations.Schema;

namespace Emploees.Domain
{
    public abstract class Catalog_Сотрудники
    {
        public string? Ref_Key { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public bool DeletionMark { get; set; }
        public bool ВАрхиве { get; set; }

        [NotMapped] 
        public static string Uri => "Catalog_Сотрудники?$format=json&$select=Ref_Key,Code,Description,DeletionMark,ВАрхиве&$inlinecount=allpages";
    }

    public class Catalog_Сотрудники_Zup : Catalog_Сотрудники 
    { }

    public class Catalog_Сотрудники_Buh : Catalog_Сотрудники
    { }
}
