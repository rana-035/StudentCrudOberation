using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public static  class FieldExtentions
    {
        public static FieldViewModel ToViewModel(this Field model)
        {
            return new FieldViewModel()
            {
                ID = model.ID,
                Name=model.Name
            };
        }
        public static FieldEditViewModel ToEditViewModel(this Field model)
        {
            return new FieldEditViewModel()
            {
                ID = model.ID,
                Name = model.Name
            };
        }
        public static Field  ToModel(this FieldEditViewModel model)
        {
            return new Field()
            {
                ID = model.ID,
                Name = model.Name
            };
        }
    }
}
