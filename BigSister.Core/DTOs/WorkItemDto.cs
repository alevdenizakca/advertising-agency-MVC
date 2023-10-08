using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigSister.Core.DTOs
{
    public class WorkItemDto:BaseDto
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string? Context { get; set; }
        public int? Order { get; set; }
    }
}
