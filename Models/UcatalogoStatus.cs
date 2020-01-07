using System;
using System.Collections.Generic;

namespace WebApiFunnyPlace.Models
{
    public partial class UcatalogoStatus
    {
        public UcatalogoStatus()
        {
            UcatalogoSexo = new HashSet<UcatalogoSexo>();
            UserOauthRegister = new HashSet<UserOauthRegister>();
            UserRegister = new HashSet<UserRegister>();
        }

        public int Id { get; set; }
        public string Valor { get; set; }
        public string Observacion { get; set; }

        public virtual ICollection<UcatalogoSexo> UcatalogoSexo { get; set; }
        public virtual ICollection<UserOauthRegister> UserOauthRegister { get; set; }
        public virtual ICollection<UserRegister> UserRegister { get; set; }
    }
}
