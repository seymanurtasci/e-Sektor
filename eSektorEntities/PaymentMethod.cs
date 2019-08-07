using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSektorEntities
{
    public class PaymentMethod
    {
        public PaymentMethod()
        {
            Tasks = new HashSet<Task>();
        }
        public Guid PaymentMethodId { get; set; }
        public string Type { get; set; }

        
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
