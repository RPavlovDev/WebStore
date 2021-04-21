using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebStore.Domain.Entities
{
    public class User : IdentityUser
    {
        public const string Administrator = "Admin";

        public const string DefaultAdminPassword = "AdPAss";

        public string Name { get; set; }

    }
}
