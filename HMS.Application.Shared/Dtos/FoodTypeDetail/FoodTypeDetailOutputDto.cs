using HMS.Application.Shared.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Dtos.FoodTypeDetail
{
    public class FoodTypeDetailOutputDto: AuditedDto
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public long FoodTypeId { get; set; }
        public string FoodType { get; set; }
        public long Quantity { get; set; }
    }
}
