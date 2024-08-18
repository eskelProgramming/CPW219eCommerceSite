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
        public DbSet<CPW219eCommerceSite.Models.RegisterViewModel> RegisterViewModel { get; set; } = default!;
    }
}
