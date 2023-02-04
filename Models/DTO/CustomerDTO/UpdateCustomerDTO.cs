using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO.CustomerDTO
{
    public class UpdateCustomerDTO
    {
         public int CostomerId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }

    }
}
