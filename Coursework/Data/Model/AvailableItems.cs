using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Data.Model
{
    public class AvailableItems
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ItemName { get; set; }
        public int QuantityAvailable { get; set; }
        public DateTime LastTaken { get; set; }
    }
}
