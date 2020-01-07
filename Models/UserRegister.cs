using System;
using System.Collections.Generic;

namespace WebApiFunnyPlace.Models
{
    public partial class UserRegister
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public DateTime? FechaCumpleanios { get; set; }
        public int? Edad { get; set; }
        public string Password { get; set; }
        public int? IdCatSexo { get; set; }
        public int? IdCatEstatus { get; set; }

        public virtual UcatalogoStatus IdCatEstatusNavigation { get; set; }
        public virtual UcatalogoSexo IdCatSexoNavigation { get; set; }
    }
}
