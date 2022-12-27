
using System;
using System.Text.Json.Serialization;

namespace IQHotel.Domain
{
    public class Phone
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long Id { get; set; }
        public string PhoneNum { get; set; }
        public DateTime Phone_verified_at { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long Hotel_id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}