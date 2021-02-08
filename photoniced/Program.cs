using photoniced.device;
using photoniced.factory;
using photoniced.ui;
using photoniced.essentials;

namespace photoniced
{
    class Program
    {
        static void Main(string[] args)
        {
            IFactory mainFactory = new Factory(args);
        }
    }
}
