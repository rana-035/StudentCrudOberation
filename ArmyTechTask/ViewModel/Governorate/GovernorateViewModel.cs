
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class GovernorateViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public List<Neighborhood> Neighborhoods { get; set; }
    }
}
