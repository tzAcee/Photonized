using System;
using System.Collections.Generic;
using System.Text;

namespace photoniced.repos
{
    public interface IMenuViewRepository 
    {
        void configure();
        void build();
        void show();
        void render();
    }
}
