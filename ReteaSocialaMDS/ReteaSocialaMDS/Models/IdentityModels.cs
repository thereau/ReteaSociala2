using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Dynamic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ReteaSocialaMDS.Models
{
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
       
       
        [Required]
        public string LastName { get; set; }

        
        [Required]
        public string AdressName { get; set; }
       
        
        
        public string TwitterHandle { get; set; }
       
        
       
        public DateTime BirthDate { get; set; }
        

       
        public DateTime AccountCreation { get; set; }

        public virtual ICollection<UserImage> UserImages { get; set; }
        
        public virtual ICollection<FriendRequest> ReceivedFriendRequests { get; set; }
        public virtual ICollection<FriendRequest> SentFriendRequests { get; set; }

        //FriendWith cand UserId este ID-ul userului
        public virtual ICollection<Friend> FriendWith { get; set; }

        //IsFriend cand OtherUserId este ID-ul userului
        public virtual ICollection<Friend> IsFriend { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }
        public virtual ICollection<Conversation> StartedBy { get; set; }
        public virtual ICollection<Conversation> NotStartedBy { get; set; }


       
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    //manage the interaction between ReteaSocialaMDS and the database where the Account data is persisted
    //We can use another database for this
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<UserImage> UserImage { get; set; }
        public DbSet<Friend> Friend { get; set; }
        public DbSet<FriendRequest> FriendRequest { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<PostComment> PostComment { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FriendRequest>().HasRequired(m => m.User).WithMany(m => m.SentFriendRequests);
            modelBuilder.Entity<FriendRequest>().HasRequired(m => m.FutureFriendrUser).WithMany(m => m.ReceivedFriendRequests);
            modelBuilder.Entity<Friend>().HasRequired(m => m.User).WithMany(m => m.FriendWith);
            modelBuilder.Entity<Friend>().HasRequired(m => m.OtherUser).WithMany(m => m.IsFriend);

            modelBuilder.Entity<Conversation>().HasRequired(m => m.FirstUser).WithMany(m => m.StartedBy);
            modelBuilder.Entity<Conversation>().HasRequired(m => m.SecondUser).WithMany(m => m.NotStartedBy);
        }
    }

}
