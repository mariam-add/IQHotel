using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace IQHotel.Domain
{
	public class Room
	{
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public long Id { get; set; }
		[ForeignKey(nameof(Hotels))]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public long Hotel_id { get; set; }
		public string Room_number { get; set; }
		public int Room_type_id { get; set; }
		public int Floor { get; set; }
		public decimal Price { get; set; }
		public int status { get; set; }
        //public RoomType roomType { get; set; }
    }


	//للاحتياط 
	//public long Id { get; set; }
	//public int Hotel_id { get; set; }
	//public string Room_number { get; set; }
	//public int Room_type_id { get; set; }
	//public int Floor { get; set; }
	//public decimal Price { get; set; }

}

