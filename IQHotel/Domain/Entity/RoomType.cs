using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IQHotel.Domain
{
    public class RoomType
    {
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public long id { get; set; }
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public long hotel_id { get; set; }
		public string type_design { get; set; }
		public int luxury_class { get; set; }
		public string type_name { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public int no_beds { get; set; }
		public decimal default_Price { get; set; }

        public static implicit operator RoomType(List<RoomType> v)
        {
            throw new NotImplementedException();
        }
    }
}
