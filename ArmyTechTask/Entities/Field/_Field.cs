using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class _Field:BaseModel
    {
     
        public string Name { get; set; }
        public virtual ICollection<_Student> _Students { get; set; }

    }
}
