using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class DbContextConnection : DbContext
    {
        public DbContextConnection(DbContextOptions<DbContextConnection> options) : base(options)
        {
        }
        public DbSet<Geometry> Geometries { get; set; }
    }
}
