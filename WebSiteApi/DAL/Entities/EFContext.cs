﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteApi.DAL.Entities
{
    public class EFContext : IdentityDbContext<IdentityUser>
    {
        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {

        }
    }
}
