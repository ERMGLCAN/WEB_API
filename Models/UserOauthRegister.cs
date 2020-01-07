using System;
using System.Collections.Generic;

namespace WebApiFunnyPlace.Models
{
    public partial class UserOauthRegister
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string IdOauth { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string Provider { get; set; }
        public int? IdCatStatus { get; set; }

        public virtual UcatalogoStatus IdCatStatusNavigation { get; set; }
    }
}
