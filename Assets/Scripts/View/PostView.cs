using System.Collections.Generic;
using DefaultNamespace.Manager;
using UnityEngine;

namespace DefaultNamespace
{
    public class PostView : MonoBehaviour
    {
        public PostItem PostItemPrefab;
        public Transform Parent;
        
        public List<PostItem> items = new List<PostItem>();

        public void Refresh()
        {
            var posts = UserManager.Instance.GetUserData().Posts;

            int i = 0;
            for (; i < posts.Count; i++)
            {
                if (i >= items.Count)
                {
                    var item = CreateOnePostItem();
                    items.Add(item);
                }
                
                items[i].gameObject.SetActive(true);
                items[i].Refresh(posts[i]);
            }

            for (; i < items.Count; i++)
            {
                items[i].gameObject.SetActive(false);
            }
        }

        private PostItem CreateOnePostItem()
        {
            var ret = Instantiate(PostItemPrefab, Parent);
            return ret;
        }
    }
}