using photoniced.essentials;
using photoniced.repos;
using System;
using System.Collections.Generic;
using System.Text;
using photoniced.device;

namespace photoniced.ui
{
    public class Menu
    {
        private IMenuView _menuView;

        public Menu(Device dev)
        {


            _menuView = create_menu_view(MenuBuilder.get_args(), MenuBuilder.get_lvl(), MenuBuilder.get_methods(dev), dev.CmdParser.DirPath);
        }

        private MenuView create_menu_view(string[] args, int level, List<MethodsHolder> methods, string start_path) => new MenuView(args, level, methods, start_path);
    }
}
