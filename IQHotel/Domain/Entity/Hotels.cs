
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IQHotel.Domain
{
    public class Hotels
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string LocationTxt { get; set; }
        public string LocationMap { get; set; }
        public int CountryId { get; set; }
        public int GovernorateId { get; set; }
        public int RegionId { get; set; }
        public int TypeId { get; set; }
        public int Stars { get; set; }
        public int FloorNo { get; set; }
        public DateTime BuildDate { get; set; }
        public string Note { get; set; }
        public int UserInsert { get; set; }
        public DateTime DateInsert { get; set; }
        public int UserUpdate { get; set; }
        public DateTime DateUpdate { get; set; }
        public List<Phone> Phones { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
