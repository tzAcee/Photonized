
using System.Collections.Generic;
using photoniced.repos;
using ConsoleTools;
using photoniced.essentials;
using System.IO;
using photoniced.common;

namespace photoniced.ui
{
    public class MenuView : ConsoleMenu, IMenuView
    {
        private List<MethodsHolder> _methods;
        private string _path;

        public MenuView(string[] args, int level, List<MethodsHolder> mh, string start_path) : base(args, level)
        {
            _methods = Required.NotNull(mh, nameof(mh));
            _path = Required.NotNull(start_path, nameof(start_path));
            render();
        }
        public void configure()
        {
            Configure(config =>
            {
              //  config.Title = "Device mounted on " + Path.GetFullPath(_path);
              //  config.EnableWriteTitle = true;
            });
            System.Console.Title = "Device mounted on " + Path.GetFullPath(_path);
        }

        public void build()
        {
            foreach(MethodsHolder method in _methods)
            {
                Add(method._description, method._method);
            }
        }

        public void show()
        {
            Show();
        }

        public void render()
        {

            build();
            configure();
            show();
        }
        
    }
}
