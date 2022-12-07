using DoggosApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoggosApi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Breed> Breeds { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}