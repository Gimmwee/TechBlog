using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBlog.Core.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PostId { get; set; }
        public string CommentHeader { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentTime { get; set; }

        public Post Post { get; set; }
    }
}
