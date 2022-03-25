namespace Avans_Devops
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public Roles Role { get; set; }
        public string Email { get; set; }

        public User(int userId, string name, Roles role, string email)
        {
            this.UserId = userId;
            this.Name = name;
            this.Role = role;
            this.Email = email;
        }

        public void ChangeRole(Roles role) 
        {
            this.Role = role;
        }
        public void Notify() { }
    }
}