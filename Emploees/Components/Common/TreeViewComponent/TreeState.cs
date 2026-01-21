namespace Emploees.Components.Common.TreeViewComponent
{
    public class TreeState
    {
        public string? SelectedNode { get; set; }

        public List<string> ExpandedNodes { get; set; } = [];
    }
}
