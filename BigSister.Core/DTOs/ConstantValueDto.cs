using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigSister.Core.DTOs
{
    public class ConstantValueDto:BaseDto
    {
        public string? Context { get; set; }
        public string Section { get; set; }
    }
}
