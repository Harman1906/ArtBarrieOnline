using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ArtBarrieOnline.Models;

namespace ArtBarrieOnline.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<ArtBarrieOnline.Models.Art> Art { get; set; }
		public DbSet<ArtBarrieOnline.Models.Category> Category { get; set; }
		public DbSet<ArtBarrieOnline.Models.Organization> Organization { get; set; }
	}
}