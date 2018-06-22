using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xFNet.Entities
{
    [Serializable]
    public abstract class Entity
    {
        public abstract object Id { get; set; }
    }
}
