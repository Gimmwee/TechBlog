using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlog.Core.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string PostContent { get; set; }
        public string? UrlSlug { get; set; }
        public string Image { get; set; }
        public bool Published { get; set; }
        public DateTime? PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public int CategoryId { get; set; }

        private int _viewCount;
        public int ViewCount
        {
            get { return _viewCount; }
            set { _viewCount = value < 0 ? 0 : value; }
        }
        public int RateCount { get; set; }
        public int TotalRate { get; set; }
        public decimal Rate { get { return RateCount == 0 ? 0 : (decimal)TotalRate / RateCount; } }

        public Category? Category { get; set; }
        //public virtual List<Category> categories { get; set; }
        public virtual ICollection<PostTagMap>? PostTagMaps { get; set; }

        public virtual ICollection<Comment>? Comments { get; set; }
      
    }
}
