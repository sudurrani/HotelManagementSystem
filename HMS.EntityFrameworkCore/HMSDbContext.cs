using HMS.Application.Shared.Common.Interfaces;
using HMS.Core.Common;
using HMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HMS.EntityFrameworkCore
{
    public class HMSDbContext : DbContext
    {

        private readonly IDateTime _dateTime;

        public HMSDbContext(DbContextOptions<HMSDbContext> options)
            : base(options)
        {
        }

        public HMSDbContext(
            DbContextOptions<HMSDbContext> options,
            IDateTime dateTime
            )
            : base(options)
        {
            _dateTime = dateTime;
        }


        public DbSet<Test> Tests { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerRoom> CustomerRooms { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<PurposeOfVisit> purposeOfVisits { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<CustomerCheckIn> CustomerCheckIns { get; set; }
        public DbSet<CustomerCheckInRoom> CustomerCheckInRooms { get; set; }

        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<FoodTypeDetail> FoodTypeDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>().HasData(
            new Employee
            {   
                Id = 1,
                Name = "Muhammad Zeb",
                CreatedBy = 1,
                CreatedDateTime = DateTime.Now,
                IsDeleted = false
            });

            modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = 1,
                Name = "admin",
                CreatedBy = 1,
                CreatedDateTime = DateTime.Now,
                IsDeleted = false
            });
            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username  = "admin",
                Password = "123",
                EmployeeId = 1,
                RoleId   = 1,
                CreatedBy = 1,
                CreatedDateTime = DateTime.Now,
                IsDeleted = false
            });

            /*
            builder.Entity<OrderItem>()
                .HasKey(s => new { s.OrderId, s.OrderItemId });
            */
            //modelBuilder.Entity<Test>().HasQueryFilter(p => !p.IsDeleted);

            //Below code implement generic query filter to get only those Entities having IsDeleted = false
            Expression<Func<AuditedEntity, bool>> filterExpr = bm => !bm.IsDeleted;
            foreach (var mutableEntityType in modelBuilder.Model.GetEntityTypes())
            {
                // check if current entity type is child of BaseModel
                if (mutableEntityType.ClrType.IsAssignableTo(typeof(AuditedEntity)))
                {
                    // modify expression to handle correct child type
                    var parameter = Expression.Parameter(mutableEntityType.ClrType);
                    var body = ReplacingExpressionVisitor.Replace(filterExpr.Parameters.First(), parameter, filterExpr.Body);
                    var lambdaExpression = Expression.Lambda(body, parameter);

                    // set filter
                    mutableEntityType.SetQueryFilter(lambdaExpression);
                }
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer(@"Server=.;Database=HotelManagementSystem;USER ID = sa; Password=P@kistan;");
            optionsBuilder.UseSqlServer(@"Server=.;Database=HotelManagementSystem;Integrated Security=True;");
            //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-GIM92EE;Initial Catalog=HotelManagementSystem;USER ID = sa; Password=P@kistan;");
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries<AuditedEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = 1;// _currentUserService.UserId; //"1";// _currentUserService.GetUserId();
                    entry.Entity.CreatedDateTime = _dateTime == null ? DateTime.Now : _dateTime.Now;
                    entry.Entity.IsDeleted = false;
                }
                else if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity.IsDeleted == true)
                    {
                        entry.Entity.DeletedBy = 1; // _currentUserService.UserId; // "1";
                        entry.Entity.DeletedDateTime = _dateTime == null ? DateTime.Now : _dateTime.Now;
                    }
                    else
                    {
                        entry.Entity.UpdatedBy = 1;// _currentUserService.UserId;  //"1";// _currentUserService.GetUserId();
                        entry.Entity.UpdatedDateTime = _dateTime == null ? DateTime.Now : _dateTime.Now;
                    }
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entry.Entity.IsDeleted = true;
                    entry.Entity.DeletedBy = 1; // _currentUserService.UserId;
                    entry.Entity.DeletedDateTime = _dateTime == null ? DateTime.Now : _dateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
