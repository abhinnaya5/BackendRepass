using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TagModel> Tags { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<GroupModel> Groups { get; set; }
        public DbSet<CommentModel> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PostModel>()
                .HasOne(p => p.user)            
                .WithMany() 
                .HasForeignKey(p => p.userId);
        }
    }
}
