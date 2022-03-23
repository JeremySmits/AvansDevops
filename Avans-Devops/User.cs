namespace Avans_Devops
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }

        public User(int userId, string name, Role role, string email)
        {
            this.UserId = userId;
            this.Name = name;
            this.Role = role;
            this.Email = email;
        }

        public void ChangeRole(Role Role) { }
        public void Notify() { }
    }
}