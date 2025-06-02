using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class NotebookEntryViewModel
    {
       
          public int EntryId { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime EntryDate { get; set; }

            [Required]
            [StringLength(5000, MinimumLength = 10)]
            public string Content { get; set; }

            [StringLength(200)]
            public string Tags { get; set; }

            public bool IsImportant { get; set; }
        }

    
}
