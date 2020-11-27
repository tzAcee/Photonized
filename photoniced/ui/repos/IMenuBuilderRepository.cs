using System;
using System.Collections.Generic;
using System.Text;
using photoniced.essentials;
using photoniced.device;

namespace photoniced.ui.repos
{
    public interface IMenuBuilderRepository
    {
        static List<MethodsHolder> get_methods(Device dev) => new List<MethodsHolder>() { };

        static string [] get_args() => new string[0];

        static int get_lvl() => 0;
    }
}
