using CPW219eCommerceSite.Models;
using Microsoft.EntityFrameworkCore;

namespace CPW219eCommerceSite.Data
{
    public class VideoGameContext : DbContext
    {
        public VideoGameContext(DbContextOptions<VideoGameContext> options) 
            : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<RegisterViewModel> RegisterViewModel { get; set; } = default!;
        public DbSet<CPW219eCommerceSite.Models.LoginViewModel> LoginViewModel { get; set; } = default!;
        public DbSet<CPW219eCommerceSite.Models.CartGameViewModel> CartGameViewModel { get; set; } = default!;
    }
}
