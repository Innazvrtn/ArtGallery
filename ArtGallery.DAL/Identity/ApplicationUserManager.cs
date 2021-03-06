﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGallery.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace ArtGallery.DAL.Identity
{
   public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
               : base(store)
        {
        }
    }
}
