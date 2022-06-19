using HMS.Application.Shared.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Shared.Dtos.Test
{
    public class TestInputDto : AuditedDto
    {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Address { get; set; }
        
    }
}
