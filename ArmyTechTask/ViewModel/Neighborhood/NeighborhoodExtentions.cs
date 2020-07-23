
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public static class NeighborhoodExtentions
    {
        public static NeighborhoodViewModel ToViewModel(this Neighborhood model)
        {
            return new NeighborhoodViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                GovernorateName=model?.Governorate.Name,
                
            };
        }
        public static NeighborhoodEditViewModel ToEditViewModel(this Neighborhood model)
        {
            return new NeighborhoodEditViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                GovernorateId = model.GovernorateId

            };
        }
        public static Neighborhood  ToModel(this NeighborhoodEditViewModel model)
        {
            return new Neighborhood()
            {
                ID = model.ID,
                Name = model.Name,
                GovernorateId = model.GovernorateId

            };
        }
    }
}
