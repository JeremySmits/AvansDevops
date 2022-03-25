using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops.Composite
{
    public class Thread : Post
    {
        public int PostID { get; }
        public BacklogItem BacklogItem { get; }
        private int ParentPostID { get; }
        private Post ParentPost { get; }
        private string CommentText { get; }
        private User OP { get; }
        private bool IsClosed { get; }

        public List<Comment> Comments { get; }

		public Thread(int postID, BacklogItem backlogItem, int parentPostID, Post parentPost, string commentText, User oP)
		{
			PostID = postID;
			BacklogItem = backlogItem;
			ParentPostID = parentPostID;
			ParentPost = parentPost;
			CommentText = commentText;
			OP = oP;
			IsClosed = false;
		}

		public void AddChild(Comment comment) {
            this.Comments.Add(comment);
        }
        public void RemoveChild(Comment comment) {
            this.Comments.Remove(comment);
        }
        public void Notify() { }
    }
}
