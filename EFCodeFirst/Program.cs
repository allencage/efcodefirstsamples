using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst
{
	class Program
	{
		static void Main(string[] args)
		{
			using(var db = new BlogContext())
			{
				Console.WriteLine("Give name for the blog: ");
				var name = Console.ReadLine();

				var blog = new Blog { Name = name };

				db.Blogs.Add(blog);
				db.SaveChanges();

				var query = db.Blogs.Select(p => p).ToList();

				foreach (var item in query)
				{
					Console.WriteLine(item.Name);
				}
			}
			Console.Read();
		}
	}

	public class Blog
	{
		public int BlogId { get; set; }
		public string Name { get; set; }
		public string Url { get; set; }

		//Note - we define this list as virtual to enable lazy loading
		public virtual List<Post> Posts { get; set; }
	}

	public class Post
	{
		public int PostId { get; set; }
		public string Name { get; set; }
		public string Content { get; set; }

		public int BlogId { get; set; }
		public virtual Blog Blog { get; set; }
	}

	public class User
	{
		//Note - data annotations because EF does not know which is the primary key for this table
		[Key]
		public string UserName { get; set; }
		public string Name { get; set; }
	}

	public class BlogContext : DbContext
	{
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<User> Users { get; set; }


		//Note - I am changing the column name using the Fluent API <- more complex than simple migrations but I can change whatever I want with this.
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.Property(u => u.Name)
				.HasColumnName("Personal_Name");
		}
	}
}
