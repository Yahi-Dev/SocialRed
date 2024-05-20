using Microsoft.EntityFrameworkCore;
using SocialRed.Core.Domain.Entities;

namespace SocialRed.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> optiones) : base(optiones) { }


        public DbSet<Publication> Publications { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Muro> Muros { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region tables
            modelBuilder.Entity<Publication>().ToTable("Publications");
            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Reply>().ToTable("Replies");
            modelBuilder.Entity<Friend>().ToTable("Friends");
            modelBuilder.Entity<Muro>().ToTable("Muro");
            #endregion

            #region "primary keys"
            modelBuilder.Entity<Publication>().HasKey(publication => publication.Id); //Lambda
            modelBuilder.Entity<Comment>().HasKey(comment => comment.Id);
            modelBuilder.Entity<Reply>().HasKey(reply => reply.Id);
            modelBuilder.Entity<Friend>().HasKey(friend => friend.Id);
            modelBuilder.Entity<Muro>().HasKey(muro => muro.Id);
            #endregion

            #region relationships
            modelBuilder.Entity<Publication>()
                    .HasMany(p => p.Comments)
                    .WithOne(c => c.Publication) 
                    .HasForeignKey(c => c.IdOfPublication) 
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Comment>()
                    .HasMany(c => c.Replies)
                    .WithOne(r => r.Comments)
                    .HasForeignKey(r => r.IdComment)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "property configuration"

            #region publicaction
            #endregion

            #region comment
            modelBuilder.Entity<Comment>()
                .Property(c => c.Comments)
                .IsRequired()
                .HasMaxLength(300);
            #endregion

            #region Reply
            modelBuilder.Entity<Reply>()
                .Property(c => c.CommentReply)
                .IsRequired()
                .HasMaxLength(300);
            #endregion

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
