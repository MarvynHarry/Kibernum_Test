namespace Kibernum_Back.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }  
        public User User { get; set; }  = new User();
    }
}
