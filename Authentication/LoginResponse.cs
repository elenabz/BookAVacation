﻿namespace BookAVacation.Authentication
{
    public class LoginResponse
    {
        public required string JwtToken { get; set; }
        public DateTime Expiration {  get; set; }
    }
}
