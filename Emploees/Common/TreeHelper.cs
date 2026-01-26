using Emploees.Abstractions;

namespace Emploees.Common
{
    public class TreeHelper
    {
        public static List<TNode> BuildTree<TNode>(List<TNode> nodes) where TNode : class, ITree<TNode>
        {
            ArgumentNullException.ThrowIfNull(nodes);

            nodes.ForEach(e => e.Children.Clear());

            List<TNode> roots = [];

            var lookup = nodes.Where(e => e.Id != null).ToDictionary(e => e.Id!);

            foreach (var node in nodes)
            {
                if (string.IsNullOrWhiteSpace(node.ParentId))
                {
                    roots.Add(node);
                    continue;
                }

                if (lookup.TryGetValue(node.ParentId, out var parent) && parent != node)
                {
                    parent.Children.Add(node);
                }
                else
                {
                    roots.Add(node);
                }
            }
            return roots;
        }

        public static List<TNode>? GetDescendantsOf<TNode>(TNode node, List<TNode> nodes) where TNode : class, ITree<TNode>
        {
            var descendants = nodes.Where(e => e.ParentId == node.Id).ToList();

            foreach (TNode descendant in descendants.ToList())
                descendants.AddRange(GetDescendantsOf(descendant, nodes) ?? Enumerable.Empty<TNode>());

            return descendants;
        }

        public static List<TNode> GetDescendantsOf<TNode>(TNode node) where TNode : class, ITree<TNode>
        {
            var result = new List<TNode>();

            void dfs(TNode current)
            {
                foreach (var child in current.Children)
                {
                    result.Add(child);
                    dfs(child);
                }
            }

            dfs(node);

            return result;
        }

        public static List<T> BuildFlattenedTree<T>(List<T> items) where T : IHasId, IHasParentId, IHasName, new()
        {
            var result = new List<T>();

            var lookup = items.ToLookup(x => x.ParentId);

            void Build(string? parentKey, int level)
            {
                var children = lookup[parentKey].OrderBy(e => e.Name);
                foreach (var item in children)
                {
                    string indent = new('\u00A0', level * 4);
                    string prefix = level > 0 ? "└─ " : "";

                    result.Add(new T
                    {
                        Id = item.Id,
                        //Name = $"{new string('-', level)} {item.Name ?? string.Empty}"
                        Name = $"{indent}{prefix}{item.Name}"
                    });

                    Build(item.Id, level + 1);
                }
            }

            Build(null, 0);

            return result;
        }

        public static List<T> BuildFlattenedCatalogTree<T>(List<T> items) where T : IHasRefKey, IHasParentKey, IHasDescription, new()
        {
            var result = new List<T>();

            var lookup = items.ToLookup(x => x.Parent_Key);

            void Build(string? parentKey, int level)
            {
                var children = lookup[parentKey].OrderBy(e => e.Description);
                foreach (var item in children)
                {
                    string indent = new('\u00A0', level * 4);
                    string prefix = level > 0 ? "└─ " : "";

                    result.Add(new T
                    {
                        Ref_Key = item.Ref_Key,
                        //Description = $"{new string('-', level)} {item.Description ?? string.Empty}"
                        Description = $"{indent}{prefix}{item.Description}"
                    });

                    Build(item.Ref_Key, level + 1);
                }
            }

            Build(null, 0);

            return result;
        }
    }
}
