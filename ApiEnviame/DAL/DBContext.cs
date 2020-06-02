using ApiEnviame.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCertiCorp.DAL
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<Envios> ENV_ENVIOS { get; set; }
        public DbSet<DetalleEnvios> ENV_DETALLE_ENVIOS { get; set; }
    }
}
