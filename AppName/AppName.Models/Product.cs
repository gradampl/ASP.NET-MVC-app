using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppName.Models
{
    public class Product: BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
