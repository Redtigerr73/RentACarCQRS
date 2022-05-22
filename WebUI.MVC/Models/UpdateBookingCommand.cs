namespace WebUI.MVC.Models
{
    public class UpdateBookingCommand
    {
        public int Id { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
    }
}
