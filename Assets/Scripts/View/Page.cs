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
        public CommentView CommentView;
        
        public EditUserPage EditUserPage;
        public EditPostPage EditPostPage;
        public EditCommentPage EditCommentPage;
        
        public Button EditUserInfo;
        public Button AddPost;
        public Button HideBtn;

        public Transform ScrollToolTrans;
        public GameObject TitleToolObj;
        public Text TitleName;

        public bool IsHide;

        private void Awake()
        {
            Instance = this;
            
            EditUserPage.InitUI();
            EditPostPage.InitUI();
            EditCommentPage.InitUI();
            
            EditUserInfo.onClick.AddListener(OnClickEditUserInfo);
            AddPost.onClick.AddListener(OnClickEditPost);
            HideBtn.onClick.AddListener(OnClickHideBtn);
        }

        private void Start()
        {
            EditUserPage.Init();
            
            Refresh();
        }

        private void Update()
        {
            bool isShow = TitleToolObj.transform.position.y < ScrollToolTrans.position.y;
            TitleToolObj.SetActive(isShow);
            TitleName.gameObject.SetActive(isShow);
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
            TitleName.text = UserManager.Instance.GetUserData().Name;
            UserView.Refresh();
            PostView.Refresh();
        }

        public void RefreshComment(PostData data)
        {
            CommentView.Refresh(data);
        }

        public void OnClickAddComment(PostData postData)
        {
            EditCommentPage.OnOpen(true, postData, new CommentData());
        }

        public void OnClickEditComment(PostData postData, CommentData commentData)
        {
            EditCommentPage.OnOpen(false, postData, commentData);
        }
        public void ShowCommentView(int index)
        {
            var comments = UserManager.Instance.GetUserData().Posts[index];
            CommentView.OnOpen(comments);
        }

        public void OnClickHideBtn()
        {
            IsHide = !IsHide;
            AddPost.gameObject.SetActive(!IsHide);
            EditUserInfo.gameObject.SetActive(!IsHide);
            HideBtn.GetComponent<CanvasGroup>().alpha = IsHide ? 0 : 1;
        }
    }
}