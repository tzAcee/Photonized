using System;
using System.Collections.Generic;
using System.Text;
using photoniced.device;
using photoniced.essentials;
using photoniced.ui.repos;

namespace photoniced.ui
{
    public class MenuBuilder : IMenuBuilder
    {
        public static string[] get_args()
        {
            return new string[0];
        }

        public static int get_lvl()
        {
            return 0;
        }

        public static List<MethodsHolder> get_methods(Device dev)
        {
            if (dev == null)
            {
                throw new ArgumentNullException();
            }
            List<MethodsHolder> res = new List<MethodsHolder>();

            res.Add(new MethodsHolder(() =>               dev.sort(), "Sort Device"));
            res.Add(new MethodsHolder(() =>               dev.delete(), "Delete Entry from Device"));
            res.Add(new MethodsHolder(() =>               dev.read(), "Read Device"));
            res.Add(new MethodsHolder(() => dev.change_device_path(), "Change Device Path"));
            res.Add(new MethodsHolder(ConsoleTools.ConsoleMenu.Close, "Close"));

            return res;
        }
    }
}
