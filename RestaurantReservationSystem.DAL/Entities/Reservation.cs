namespace RestaurantReservationSystem.DAL.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationTime { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public string UserId { get; set; }
    }
}
