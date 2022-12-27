using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IQHotel.Domain
{
    public class Booking
    {
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public int id { get; set; }
		public long hotel_id { get; set; }
		public int customer_id { get; set; }
		public int floor_id { get; set; }
		public long room_id { get; set; }
		public DateTime start_booking { get; set; }
		public DateTime end_booking { get; set; }
		public DateTime arrrival { get; set; }
		public DateTime checkout { get; set; }
		public DateTime date_insert { get; set; }
		public int user_id { get; set; }
		public bool isCanceled { get; set; }
	}
}
