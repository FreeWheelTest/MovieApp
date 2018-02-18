namespace MovieApp.Interfaces
{
    public interface IRating
    {
        int Id { get; set; }
        int MovieId { get; set; }
        int UserId { get; set; }
        double Score { get; set; }
    }
}
