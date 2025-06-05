using System;
using DefaultNamespace.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class CommentItem : MonoBehaviour
    {
        public GameRawImage AvatarImage;
        public Text Name;
        public Text Content;
        public Text PraiseCountText;
        public Text CommentCountText;
        public Button ListBtn;
        public GameObject ListPanel;

        public Button EditBtn;
        public Button RemoveBtn;

        private PostData _postData;
        private CommentData _commentData;

        private void Awake()
        {
            ListBtn.onClick.AddListener(OnClickListBtn);
            EditBtn.onClick.AddListener(OnClickEditBtn);
            RemoveBtn.onClick.AddListener(OnClickRemoveBtn);
            ListPanel.gameObject.SetActive(false);
        }

        public void Refresh(PostData postData, CommentData commentData)
        {
            _postData = postData;
            _commentData = commentData;
            
            ListPanel.gameObject.SetActive(false);
            
            if (!string.IsNullOrEmpty(commentData.Avatar))
            {
                AvatarImage.Init(GameHelper.GetImagePath(commentData.Avatar));
            }
            else
            {
                AvatarImage.Clear();
            }

            Name.text = commentData.Name;
            Content.text = commentData.Content;
            PraiseCountText.text = commentData.PraiseCountStr;
            CommentCountText.text = commentData.CommentCount.ToString();
        }
        
        private void OnClickListBtn()
        {
            ListPanel.gameObject.SetActive(!ListPanel.gameObject.activeSelf);
        }

        private void OnClickEditBtn()
        {
            Page.Instance.OnClickEditComment(_postData, _commentData);
        }

        private void OnClickRemoveBtn()
        {
            _postData.Comments.Remove(_commentData);
            UserManager.Instance.Save();
            Page.Instance.RefreshComment(_postData);
        }
    }
}