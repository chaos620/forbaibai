using System.Collections.Generic;

namespace DefaultNamespace.Manager
{
    public class UserData
    {
        public string Name;
        public string NameTitle;
        public string Title;
        public string Signature;
        public List<PostData> Posts = new List<PostData>();
    }

    public class PostData
    {
        public string Content;
        public string Time;
        public string ImageName;
        public int PraiseCount;
        public int CommentCount;
        public List<CommentData> Comments = new List<CommentData>();
    }

    public class CommentData
    {
        public string Avatar;
        public string Name;
        public string Content;
        public int PraiseCount;
        public string Time;
    }
}