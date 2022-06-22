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
        public BacklogItem BacklogItem { get; }
        public bool IsClosed { get; set; }
        public List<Post> Posts { get; } = new List<Post>();
        public List<Observer> Observers { get; } = new List<Observer>();

        public Thread(int postID, BacklogItem backlogItem, Thread parentPost, string commentText, User oP)
        {
            PostID = postID;
            BacklogItem = backlogItem;
            ParentPost = parentPost;
            CommentText = commentText;
            OP = oP;
            IsClosed = false;
        }
        public override void AddChild(Post Post)
        {
            if (!IsClosed && BacklogItem.State != PhaseState.Done)
            {
                Observer observer = new Observer();
                observer.Receiver = this.OP;
                string message = Post.OP + "responded to your thread with: " + Post.CommentText;
                observer.Message = message;
                NotifyObservers();

                this.Posts.Add(Post);
            }
        }
        public override void RemoveChild(Post Post)
        {
            if (!IsClosed && BacklogItem.State != PhaseState.Done)
            {
                this.Posts.Remove(Post);

            }
        }

        public void AttachObserver(Observer observer)
        {
            this.Observers.Add(observer);
        }
        public void DetachObserver(Observer observer)
        {
            this.Observers.Remove(observer);
        }
        public void NotifyObservers()
        {
            foreach (var o in Observers)
            {
                o.SendMessage();
            }
        }
        public void OpenThread()
        {
            if (this.IsClosed == true && ParentPost == null)
                this.IsClosed = false;
            else
            {
                Console.WriteLine("Thread is already open");
            }
        }
        public void CloseThread()
        {
            if (this.IsClosed == false && ParentPost == null)
                this.IsClosed = true;
            else
            {
                Console.WriteLine("Thread is already closed");
            }
        }
    }

}
