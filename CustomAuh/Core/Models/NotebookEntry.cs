using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class NotebookEntry
    {
        public int EntryId { get; set; }
        public string UserId { get; set; }
        public DateTime EntryDate { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public bool IsImportant { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
