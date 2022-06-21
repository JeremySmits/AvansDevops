using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops.Composite
{
    public abstract class Post
    {
        public int PostID { get; set; }
        public Thread ParentPost { get; set; }
        public string CommentText { get; set; }
        public User OP { get; set; }

        public virtual void AddChild(Post Post) { }
        public virtual void RemoveChild(Post Post) { }

        public void SetCommentText(string text)
        {
            CommentText = text;
        }
    }
}
