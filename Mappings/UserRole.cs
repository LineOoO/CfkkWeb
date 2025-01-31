namespace CfkkWeb.Mappings
{
    public class UserRole
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is UserRole other)
            {
                return User.Id == other.User.Id && Role.Id == other.Role.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(User.Id, Role.Id);
        }
    }
}
