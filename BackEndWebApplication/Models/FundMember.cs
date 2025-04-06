namespace BackEndWebApplication.Models
{
    public class FundMember
    {
        public Guid UserID { get; set; }
        public Guid FundID { get; set; }

        public virtual User? User { get; set; }
        public virtual VolunteerFund? Fund { get; set; }
    }
}
