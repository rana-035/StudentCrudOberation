
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class _Student:BaseModel
    {
     
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int GovernorateId { get; set; }
        public int NeighborhoodId { get; set; }
        public int FieldId { get; set; }
        public virtual _Field _Field { get; set; }
        public virtual _Governorate _Governorate { get; set; }
        public virtual Neighborhood _Neighborhood { get; set; }
   





    }
}
