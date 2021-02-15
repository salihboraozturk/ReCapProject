using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public string CarName { get; set; }
        public string CompanyName { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ? ReturnDate { get; set; }

    }
}
