using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Data.Model
{
	public class ItemRequest
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; }
        public int Quantity { get; set; }
		public string Requested_By { get; set; }
		public DateTime Requested_Date { get; set; }

		public string RequestStatus { get; set; }

		public string Handler { get; set; }
        public DateTime DateHandled { get; set; }

    }
}
