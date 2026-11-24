using System;
using System.Drawing;

namespace QuizSystem
{
    public class UserAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public Image Photo { get; set; }     // profile picture, kept in memory only (null = initials)

        public UserAccount(string username, string password, string role, string fullName)
        {
            Username = username;
            Password = password;
            Role = role;
            FullName = fullName;
            Email = username.ToLower() + "@eduquiz.com";
            CreatedAt = DateTime.Now;
        }
    }
}