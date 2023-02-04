using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// to create this Model for table creation.
    /// </summary>
    public class FoodItem
    {
        /// <summary>
        /// created constants between the regions.
        /// </summary>
        #region Constants
        public const int PRICELENGTH = 50;
        #endregion
        /// <summary>
        /// all required fields.
        /// </summary>
        #region Properties
        [Key]
        public int FoodID { get; set; }
        [Required]
        [StringLength(PRICELENGTH)]       
        public decimal Price { get; set; }
        public ItemCategory ItemCategory { get; set; }

        [ForeignKey("FkCustomerId")]
        public Customer Customer { get; set; }
        public int FkCustomerId { get; set; }

        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int Modifiedby { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        #endregion        
        #region Association
        #endregion
    }
    /// <summary>
    ///this is created for number of food items.
    /// </summary>
    public enum ItemCategory
    {
        Edly = 1, Dosa, Voda, Bonda
    }
}
