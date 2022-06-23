using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops.Composite
{
    public class Comment : Post
    {
		public Comment(int postID,  Thread parentPost, string commentText, User OP)
		{
			this.PostID = postID;
			this.ParentPost = parentPost;
			this.CommentText = commentText;
			this.OP = OP;
		}

		public override void AddChild(Post Post) 
		{
			Thread tempThread = new(PostID, ParentPost.BacklogItem, ParentPost, CommentText, OP);
			tempThread.AddChild(Post);

			ParentPost.Posts.Add(tempThread);
			ParentPost.Posts.Remove(this);
		}

		public override void RemoveChild(Post Post) { Console.WriteLine("Comments has no children."); }
	}
}
