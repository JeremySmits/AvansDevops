using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops.Composite
{
    public class Comment : Post
    {
        private int PostID { get; }
        private BacklogItem BacklogItem { get; }
        private int ParentPostID { get; }
        private Post ParentPost { get; }
        public string CommentText { get; }
        public User OP { get; }
        private bool IsClosed { get; }

		public Comment(int postID, BacklogItem backlogItem, int parentPostID, Post parentPost, string commentText, User oP)
		{
			this.PostID = postID;
			this.BacklogItem = backlogItem;
			this.ParentPostID = parentPostID;
			this.ParentPost = parentPost;
			this.CommentText = commentText;
			this.OP = oP;
			this.IsClosed = false;
		}
	}
}
