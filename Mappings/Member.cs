namespace CfkkWeb.Mappings
{
    public class Member
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhoneNum { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual int wp_club { get; set; }
        public virtual int wp_belt { get; set; }

    }
}
