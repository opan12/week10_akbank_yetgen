﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week_10_1.Domain.Entitiies;
using Week_10_1.Domain.Enum;

namespace Week_10_1.Domain.Entities
{
  
        public class Student : EntityBase<Guid>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public string Company { get; set; }
            public bool IsGraduated { get; set; }
            public Int16 Age { get; set; }
            public decimal? RegistrationFee { get; set; }
            public Gender Gender { get; set; }
        }


    }

