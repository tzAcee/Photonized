using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace photoniced.essentials.path_tree
{
    public class Node
    {
        public string Name { get; set; }
        public List<Node> Children { get; set; }

        public Node(string path)
        {
            get_children(path);
        }

        void get_children(string path)
        {
            if (Directory.Exists(path)) // Is File
            {
                Name = "[] "+new DirectoryInfo(path).Name;
                Children = new List<Node>();
                string[] files = 
                    Directory.GetFileSystemEntries(path, "*", SearchOption.TopDirectoryOnly);

                foreach (var file in files)
                {
                    Children.Add(new Node(file));
                }
            }
            else if(File.Exists(path))
            {
                Name = new FileInfo(path).Name;
                Children = new List<Node>();
            }
        }
    }
}