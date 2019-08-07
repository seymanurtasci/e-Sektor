using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSektorEntities
{
    public class Authorize
    {
        public Authorize()
        {
            Members = new HashSet<Members>();        
        }

        public Guid AuthorizeId { get; set; }
        public string Type { get; set; }


        public virtual ICollection<Members> Members { get; set; }

    }
}
