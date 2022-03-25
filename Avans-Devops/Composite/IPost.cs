using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avans_Devops.Composite
{
    public abstract class Post
    {
        private int PostID { get; }
        private BacklogItem BacklogItem { get; }
        private int ParentPostID { get; }
        private Post ParentPost { get; }
        private string CommentText { get; }
        private User OP { get; }
        private bool IsActive { get; }

        public void setActive(bool SetActive) {
            if (!SetActive && this.IsActive) {
                // Close active thread
            } else if (SetActive && !this.IsActive) {
                // Open closed thread
            } else if (!SetActive && !this.IsActive) {
                // Close already closed thread
                throw new NotSupportedException("Can't close a thread that is already closed.");
            } else if (SetActive && this.IsActive) {
                // Open already active thread
                throw new NotSupportedException("Can't open a thread that's already open.");
                
            }

        }
    }
}
