using EvesisTestWebApplication.Models.Account;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvesisTestWebApplication.Data
{
	public class EvesisDbContext : IdentityDbContext<User>
	{
		public EvesisDbContext(DbContextOptions<EvesisDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<User>(b =>
			{
				b.ToTable("Users");
			});
		}
	}
}
