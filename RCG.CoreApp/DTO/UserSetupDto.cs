﻿namespace RCG.CoreApp.DTO
{
    public class UserSetupDto
    {
        public long? UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
