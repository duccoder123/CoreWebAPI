﻿namespace VillaAPI.Models.Dto
{
    public class LoginResponseDTO
    {
        public UserDTO User { get; set; } 
        public string Roles { get; set; }   
        public string Token { get; set; }
    }
}
