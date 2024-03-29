﻿using Microsoft.AspNet.Identity.EntityFramework;
using BighornWildlife.API.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BighornWildlife.API
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            :base("AuthContext")
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}