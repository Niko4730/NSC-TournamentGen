﻿namespace NSC_TournamentGen.Security.Models
{
    public class AuthUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        public string Role { get; set; }
        public byte[] Salt { get; set; }
    }
}
