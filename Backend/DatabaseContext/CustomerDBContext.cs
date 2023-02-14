using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.DatabaseContext
{
    public class CustomerDBContext : DbContext
    {
        IConfiguration _configuration;
        public CustomerDBContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        //    public CustomerDBContext(DbContextOptions<CustomerDBContext> options)
        //: base(options)
        //    {
        //    }
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

            }
        }

       // protected override void OnModelCreating(ModelBuilder modelBuilder)
       // {
            // seed the Country Table  with Dummy data
            //modelBuilder.Entity<Country>().HasData(
            //    new Country
            //    {
            //        //Id = -1,
            //        CountryName = "Bangladesh"
            //    }, new Country
            //    {
            //        //Id = -1,
            //        CountryName = "India"
            //    }
                //new Country
                //{
                //    Id = -1,
                //    CountryName = "Nepal"
                //}, new Country
                //{
                //    Id = -1,
                //    CountryName = "Bhutan"
                //}, new Country
                //{
                //    Id = -1,
                //    CountryName = "Srilanka"
                //}, new Country
                //{
                //    Id = -1,
                //    CountryName = "Indonesia"
                //}, new Country
                //{
                //    Id = -1,
                //    CountryName = "USA"
                //}, new Country
                //{
                //    Id = -1,
                //    CountryName = "Canada"
                //}, new Country
                //{
                //    Id = -1,
                //    CountryName = "Zimbabwe"
                //}, new Country
                //{
                //    Id = -1,
                //    CountryName = "Maldive"
                //}, new Country
                //{
                //    Id = -1,
                //    CountryName = "Mongolia"
                //}
             //);
            //base.OnModelCreating(modelBuilder);

        //}






    }
}

