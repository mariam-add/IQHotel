using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IQHotel.Domain
{
    public class User
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int user_id { get; set; }
        public string PhoneNum { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Role_id { get; set; }
        public int Profile_id { get; set; }
    }
}
