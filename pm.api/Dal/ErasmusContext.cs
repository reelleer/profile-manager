using Microsoft.EntityFrameworkCore;
using Pm.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pm.Api.Dal
{
    public class ErasmusContext : DbContext
    {
        public ErasmusContext(DbContextOptions<ErasmusContext> options) : base(options)
        {
        }
        public DbSet<Profile> Profiles { get; set; }
    }
}
