using System.ComponentModel.DataAnnotations;

namespace BuyPhone.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
