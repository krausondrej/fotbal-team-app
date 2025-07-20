using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using fotbalTeam.Domain.Entities;
using fotbalTeam.Infrastructure.Identity; // Assuming you have Identity classes for roles and user management
using fotbalTeam.Infrastructure.Seeding; // Importing seeding classes for initial data

namespace fotbalTeam.Infrastructure.Database
{
    public class FotbalTeamDbContext : IdentityDbContext<User, Role, int> // Inherits from IdentityDbContext for user/role management
    {
        // DbSet properties for each entity
        public DbSet<Match> Matches { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Carousel> Carousels { get; set; }

        // Constructor for DbContextOptions, passed to the base class
        public FotbalTeamDbContext(DbContextOptions<FotbalTeamDbContext> options)
            : base(options)
        {
        }

        // Overriding OnModelCreating to handle seeding and model configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding data for Player, Training, Match, and Performance entities
            // Seeding Player data
            PlayerInit playerInit = new PlayerInit();
            modelBuilder.Entity<Player>().HasData(playerInit.GetPlayers());

            // Seeding Training data
            TrainingInit trainingInit = new TrainingInit();
            modelBuilder.Entity<Training>().HasData(trainingInit.GetTrainings());

            // Seeding Match data
            MatchInit matchInit = new MatchInit();
            modelBuilder.Entity<Match>().HasData(matchInit.GetMatches());

            // Seeding Performance data
            PerformanceInit performanceInit = new PerformanceInit();
            modelBuilder.Entity<Performance>().HasData(performanceInit.GetPerformances());

            // Seeding Carousel data (if applicable)
            CarouselInit carouselInit = new CarouselInit();
            modelBuilder.Entity<Carousel>().HasData(carouselInit.GetCarousels());

            // Identity - roles and user initialization (if applicable)
            // You can seed Identity roles, users, and user roles here
            RolesInit rolesInit = new RolesInit();
            modelBuilder.Entity<Role>().HasData(rolesInit.GetRolesALS());

            UserInit userInit = new UserInit();
            User admin = userInit.GetAdmin();
            User lecturer = userInit.GetLecturer();
            modelBuilder.Entity<User>().HasData(admin, lecturer);

            UserRolesInit userRolesInit = new UserRolesInit();
            List<IdentityUserRole<int>> adminUserRoles = userRolesInit.GetRolesForAdmin();
            List<IdentityUserRole<int>> lecturerUserRoles = userRolesInit.GetRolesForLecturer();
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRoles);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(lecturerUserRoles);
        }
    }
}
