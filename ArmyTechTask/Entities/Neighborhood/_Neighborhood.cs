using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Neighborhood:BaseModel
    {
       
        public string Name { get; set; }
        public int GovernorateId { get; set; }
        public virtual ICollection<_Student> _Students { get; set; }
        public virtual _Governorate _Governorate { get; set; }

    }
}
