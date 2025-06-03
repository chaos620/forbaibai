using System;
using DefaultNamespace.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Page : MonoBehaviour
    {
        public static Page Instance;

        public UserView UserView;
        public PostView PostView;
        
        public EditUserPage EditUserPage;
        public EditPostPage EditPostPage;
        
        public Button EditUserInfo;
        public Button AddPost;
        public Button HideBtn;

        private void Awake()
        {
            Instance = this;
            
            EditUserPage.InitUI();
            EditPostPage.InitUI();
            
            EditUserInfo.onClick.AddListener(OnClickEditUserInfo);
            AddPost.onClick.AddListener(OnClickEditPost);
        }

        private void Start()
        {
            EditUserPage.Init();
            
            Refresh();
        }

        public void OnClickEditUserInfo()
        {
            EditUserPage.gameObject.SetActive(true);
        }
        
        public void OnClickEditPost()
        {
            var postData = new PostData();
            EditPostPage.OnOpen(true, postData);
        }

        public void Refresh()
        {
            UserView.Refresh();
            PostView.Refresh();
        }
    }
}