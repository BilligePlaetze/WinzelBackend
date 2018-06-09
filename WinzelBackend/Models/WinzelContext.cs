﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinzelBackend.Models
{
    using Microsoft.EntityFrameworkCore;

    public class WinzelContext : DbContext
    {
        public WinzelContext(DbContextOptions<WinzelContext> options)
            : base(options)
        {
        }

        public DbSet<Winzel> Winzels { get; set; }
    }
}
