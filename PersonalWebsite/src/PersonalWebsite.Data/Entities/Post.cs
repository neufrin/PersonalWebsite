﻿using PersonalWebsite.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Data.Entities
{
    public class Post
    {
        public int PostId { get; set; }

        public Guid Guid { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? PublishedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Title { get; set; }

        public string Excerpt { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public PostStatusType Status { get; set; }

        public virtual ICollection<PostCategory> PostCategories { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }

        public int? HeaderImageId { get; set; }

        [ForeignKey("HeaderImageId")]
        public Image HeaderImage { get; set; }

        public virtual Adventure Adventure { get; set; }

        public int? ParentPostId { get; set; }

        [ForeignKey("ParentPostId")]
        public Post ParentPost { get; set; }

    }
}
