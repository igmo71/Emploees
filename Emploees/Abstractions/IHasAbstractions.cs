namespace Emploees.Abstractions
{
    public interface IHasAbstractions
    {
    }

    public interface IHasId
    {
        public string? Id { get; set; }
    }
    public interface IHasParentId
    {
        public string? ParentId { get; set; }
    }
    public interface IHasName
    {
        public string? Name { get; set; }
    }

    public interface IHasRefKey
    {
        public string? Ref_Key { get; set; }
    }

    public interface IHasParentKey
    {
        public string? Parent_Key { get; set; }
    }

    public interface IHasDescription
    {
        public string? Description { get; set; }
    }
}
