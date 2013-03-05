using System;
using System.Collections.Generic;

namespace _1_SchoolHierarchy
{
    class Comment
    {
        private string commentText;

        #region Constructors
        public Comment()
        {
            this.commentText = string.Empty;
        }

        public Comment(string comment)
        {
            this.commentText = comment;
        }
        #endregion

        public string CommentText
        {
            get { return this.commentText; }
            set { this.commentText = value; }
        }

        public void AddComment(string comment)
        {
            this.commentText = comment;
        }
    }
}
