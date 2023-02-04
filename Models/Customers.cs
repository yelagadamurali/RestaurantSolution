using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer
    {
        /// <summary>
        /// created constructor for don't shows null values at the time of object initialization.
        /// </summary> 
        public Customer()
        {
            FoodItems = new List<FoodItem>();
        }
        #region Constants
        public const int NAMELENGTH = 50;
        public const int MOBILENUMBER = 20;

        #endregion
        #region Properties
        [Key]
        public int PKCostomerId { get; set; }
        [Required]
        [StringLength(NAMELENGTH)]        
        public string Name { get; set; }
        [Required]
        [StringLength(MOBILENUMBER)]
        public string PhoneNumber { get; set; }
        public PaymentType PaymentType { get; set; }      
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int Modifiedby { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        #endregion
        #region Associations
        [InverseProperty("Customer")]
        public List<FoodItem> FoodItems { get; set; }
        #endregion

    }
    /// <summary>
    /// this is created for Payment Mode
    /// </summary>
    public enum PaymentType
    {
        Online=1,Card,Cash
    };
}
