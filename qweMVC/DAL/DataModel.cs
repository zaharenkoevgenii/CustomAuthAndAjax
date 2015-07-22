using System.Data.Entity;
using qweMVC.DAL;
using qweMVC.Models;

public class DataContext : DbContext
{
    public DataContext()
        : base("DefaultConnection")
    {

    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
        .HasMany(u => u.Roles)
        .WithMany(r => r.Users)
        .Map(m =>
        {
            m.ToTable("UserRoles");
            m.MapLeftKey("UserId");
            m.MapRightKey("RoleId");
        });
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Comments> Comments { get; set; }
}