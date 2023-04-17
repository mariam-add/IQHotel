
using System;

namespace IQHotel.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string NoNationalCardLink { get; set; }
        public string NoPassport { get; set; }
        public string PhotoCustomer { get; set; }
        public string PhotoCard { get; set; }
        public bool IsActive { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeleteDate { get; set; }
        public byte[] Version { get; set; }
    }
}