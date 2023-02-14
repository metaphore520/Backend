using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.DatabaseContext
{
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext()
        {
        }

        public CustomerDBContext(DbContextOptions<CustomerDBContext> options)
    : base(options)
        {
        }

        // "Server=DESKTOP-VBDPK1F\\SQLEXPRESS;Database=Customer;Trusted_Connection=True";
        //"server=DESKTOP-VBDPK1F\\SQLEXPRESS; database=Customer; Integrated Security=true"


        //"Server=DESKTOP-R1A1J4P\\SQLEXPRESS;Database=Employee;Trusted_Connection=True;"
        //"Server=DESKTOP-R1A1J4P\\SQLEXPRESS;Database=Employee;Trust Server Certificate=true;Trusted_Connection=True;"
        public DbSet<Country> Country { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerAddress> CustomerAddress { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*
                #warning To protect potentially sensitive information in your connection string, you should move 
                #it out of source code.
                See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                */
                optionsBuilder.UseSqlServer("Server=DESKTOP-R1A1J4P\\SQLEXPRESS;Database=Customer;Trust Server Certificate=true;Trusted_Connection=True;");

                //string connectionString = this._configuration.GetConnectionString("Default");

            }
        }


    }
}

