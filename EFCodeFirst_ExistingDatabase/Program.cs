using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirst_ExistingDatabase
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var db = new BlogsContext())
			{
				Console.WriteLine("Give blog name: ");
				var name = Console.ReadLine();

				var blog = new Blog { Name = name };

				db.Blogs.Add(blog);
				db.SaveChanges();

				var query = db.Blogs.Select(p => p).ToList();
				Console.WriteLine("List of all blogs: ");
				foreach (var item in query)
				{
					Console.WriteLine(item.Name);
				}

				Console.WriteLine("Press any key to quit the application......");
				Console.Read();
			}
		}
	}
}
