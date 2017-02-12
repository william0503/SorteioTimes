using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteioTimes.Models
{
    public class BaseModel
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
    }
}
