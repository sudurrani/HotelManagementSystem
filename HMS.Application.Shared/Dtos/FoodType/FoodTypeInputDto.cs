using HMS.Application.Shared.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Dtos.FoodType
{
    public class FoodTypeInputDto:AuditedDto
    {
        public string Name { get; set; }
    }
}
