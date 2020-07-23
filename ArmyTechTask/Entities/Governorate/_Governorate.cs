using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class _Governorate:BaseModel
    {
        
        public string Name { get; set; }
        public virtual ICollection<_Student> _Students { get; set; }
        public virtual ICollection<Neighborhood> _Neighborhoods { get; set; }

    }
}
