using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Model
{
    class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DueDate { get; set; }
        public int StatusId { get; set; } //foreign key
        public Status Status { get; set; } // navigation property
    }
}
