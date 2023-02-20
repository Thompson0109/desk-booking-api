
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleTest.Entities
{

    public class Desk
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //Geenrated key on new desk being added
        public int Id { get; set; }
        public int DeskNumber { get; set; }
        public bool isAvailable { get; set; } = false;

        public Desk(int deskNumber)
        {
            //We convey that we want this desk class to always have a desk number in persistant storage
            DeskNumber = deskNumber;
        }
        public ICollection<BookingStatus> BookingStatus { get; set; }
            = new List<BookingStatus>();
    }
}