using System;
using System.Collections.Generic;
using System.Text;

namespace laba_3._1
{
    public class Rigestry
    {
        private Dictionary<string, IFabric> _registry;
        public Rigestry(Dictionary<string, IFabric> registry)
        {
            _registry = registry;
        }

        public Shape? CreateShape(string[] typeOptions)
        {
            if (_registry.ContainsKey(typeOptions[0]))
            {
                return _registry[typeOptions[0]].CreateShape(typeOptions);
            }
            return null;
        }

    }
}
