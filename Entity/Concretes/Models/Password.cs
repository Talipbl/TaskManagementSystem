using Entity.Abstracts;
using System;
using System.Collections.Generic;

namespace Entity.Concretes.Models
{
    public class Password : IEntity
    {
        public int UserId { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public virtual User User { get; set; }
    }
}
