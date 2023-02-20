
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleTest.Entities
{

    public class BookingStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //Strings need to be set to a value of empty if not nullable
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public Desk? desk { get; set; }
        [ForeignKey("CityId")]
        public int deskID { get; set; }
        public string? Description { get; set; }

        public BookingStatus(string name)
        {
            Name = name;
        }
    }
}