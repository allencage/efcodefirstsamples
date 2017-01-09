namespace EFCodeFirst_ExistingDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post
    {
        public int PostId { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }
    }
}
