using System;
using System.Collections.Generic;

namespace WebApiFunnyPlace.Models
{
    public partial class UcatalogoSexo
    {
        public UcatalogoSexo()
        {
            UserRegister = new HashSet<UserRegister>();
        }

        public int Id { get; set; }
        public string Valor { get; set; }
        public string Observacion { get; set; }
        public int? IdCatStatus { get; set; }

        public virtual UcatalogoStatus IdCatStatusNavigation { get; set; }
        public virtual ICollection<UserRegister> UserRegister { get; set; }
    }
}
