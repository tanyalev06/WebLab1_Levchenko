using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebLab1_Levchenko.DAL.Entities
{
    public class ApplicationUser : IdentityUser

    {
        public byte[] AvatarImage { get; set; }
    }
}
