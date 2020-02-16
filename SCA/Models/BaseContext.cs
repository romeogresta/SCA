using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace SCA.Models {
	public class BaseContext<T> : DbContext where T : class {
		public DbSet<T> Records { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			if (!optionsBuilder.IsConfigured) {
				optionsBuilder.UseInMemoryDatabase("SCA");
			}
		}
	}
}