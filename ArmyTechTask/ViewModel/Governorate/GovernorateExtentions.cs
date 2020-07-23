using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public static  class GovernorateExtentions
    {
        public static GovernorateViewModel ToViewModel(this Governorate model)
        {
            return new GovernorateViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                Neighborhoods = model?.Neighborhoods.ToList()
            };
        }
        public static GovernorateEditViewModel ToEditViewModel(this Governorate model)
        {
            return new GovernorateEditViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                
            };
        }
        public static Governorate  ToModel(this GovernorateEditViewModel model)
        {
            return new Governorate()
            {
                ID = model.ID,
                Name = model.Name,

            };
        }
    }
}
