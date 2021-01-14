namespace photoniced.essentials.path_tree
{
    public class NodePrinter : INodePrinter
    {
        public static void print_tree(Node tree, string indent, bool last)
        {
            if (tree.Children == null) return;
            System.Console.WriteLine(indent + "+- " + tree.Name);
            indent += last ? "   " : "|  ";

            for (int i = 0; i < tree.Children.Count; i++)
            {
                print_tree(tree.Children[i], indent, i == tree.Children.Count - 1);
            }
        }
    }
}