using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class StudentEditViewModel
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
 
        public DateTime BirthDate { get; set; }
        [Required]
        public int GovernorateId { get; set; }
        public int? NeighborhoodId { get; set; }
        [Required]
        public int FieldId { get; set; }

    }
}
