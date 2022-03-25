using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Devops.Observe;

namespace Avans_Devops.Composite
{
    public class Thread : Post, IObservable
    {
        public int PostID { get; }
        public BacklogItem BacklogItem { get; }
        private int ParentPostID { get; }
        private Post ParentPost { get; }
        private string CommentText { get; }
        private User OP { get; }
        private bool IsClosed { get; }
        public List<Comment> Comments { get; } = new List<Comment>();
        public List<Observer> Observers { get; } = new List<Observer>();

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
            NotifyObservers(comment);
        }
        public void RemoveChild(Comment comment) {
            this.Comments.Remove(comment);
        }

        public void AttachObserver(Observer observer) {
            this.Observers.Add(observer);
        }
        public void DetachObserver(Observer observer) {
            this.Observers.Remove(observer);
        }
        public void NotifyObservers(Comment comment) {
            string message = comment.OP + "responded to your thread with: " + comment.CommentText;
            foreach (var o in Observers) {
                o.SendMessage(this.OP, message);
            }
        }
    }
}
