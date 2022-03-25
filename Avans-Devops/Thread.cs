using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops
{
    public class Thread
    {
        public int PostID { get; set; }
        public BacklogItem BlacklogItem { get; set; }
        public int ParentPostID { get; set; }
        public IPost ParentPost { get; set; }
        public int CommentText { get; set; }
        public User OP { get; set; }
        public bool IsClosed { get; set; }


        public void AddChild() { }
        public void RemoveChild() { }
        public void CloseDiscussion() { }
        public void Notify() { }
    }
}
