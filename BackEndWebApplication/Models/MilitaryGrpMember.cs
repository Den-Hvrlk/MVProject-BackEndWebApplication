namespace BackEndWebApplication.Models
{
    public class MilitaryGrpMember
    {
        public Guid UserID { get; set; }
        public Guid GroupID { get; set; }

        public virtual User? User { get; set; }
        public virtual MilitaryGroup? Group { get; set; }
    }

}
