using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RestaurantReservationSystem.DAL.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public ICollection<Table> Tables { get; set; }
    }
}
