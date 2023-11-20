using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_10_1.Domain.Entities
{
    public interface IModifiedByEntity
    {
        public string? ModifiedByUserId { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
    }
}
