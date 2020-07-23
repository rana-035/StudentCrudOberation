using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public static class StudentExtentions
    {
        public static StudentViewModel ToViewModel(this Student model)
        {
            return new StudentViewModel()
            {
                ID = model.ID,
                BirthDate = model.BirthDate,
                Name = model.Name,
                FieldName = model.Field?.Name,
                GovernorateName=model.Governorate?.Name,
                NeighborhoodName=model.Neighborhood?.Name

            };
        }
        public static StudentEditViewModel ToEditViewModel(this Student model)
        {
            return new StudentEditViewModel()
            {
                ID = model.ID,
                BirthDate = model.BirthDate,
                Name = model.Name,
               FieldId=model.FieldId,
               GovernorateId=model.GovernorateId,
               NeighborhoodId=model?.NeighborhoodId

            };
        }
        public static Student  ToModel(this StudentEditViewModel model)
        {
            return new Student()
            {
                ID = model.ID,
                BirthDate = model.BirthDate,
                Name = model.Name,
                FieldId = model.FieldId,
                GovernorateId = model.GovernorateId,
                NeighborhoodId = model.NeighborhoodId

            };
        }
    }
}
