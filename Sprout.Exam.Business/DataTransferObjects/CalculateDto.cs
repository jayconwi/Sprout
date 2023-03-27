using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.DataTransferObjects
{
    public class CalculateDto
    {
        public int AbsentDays { get; set; }
        public decimal WorkedDays { get; set; }
        public int Id { get; set; }
    }
}
