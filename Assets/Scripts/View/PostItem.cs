using System;
using DefaultNamespace.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PostItem : MonoBehaviour
    {
        public Text NameText;
        public GameRawImage Avatar;
        public Text TimeText;
        public Text ContentText;
        public GameRawImage MainRawImage;
        public Text GoodText;
        public Text CommentText;
        public Button EditButton;
        public EditPostButtonView EditPostButtonView;
        public Button Commentbtn;
        private int _index;

        private void Awake()
        {
            EditButton.onClick.AddListener(OnClickEditButton);
            Commentbtn.onClick.AddListener(OnClickCommentBtn);
        }

        public void Refresh(int index, PostData data)
        {
            _index = index;
            var userData = UserManager.Instance.GetUserData();

            NameText.text = userData.Name;
            Avatar.Init(GameHelper.GetAvatarPath());
            TimeText.text = data.Time;
            ContentText.text = data.Content;
            if (string.IsNullOrEmpty(data.ImageName))
            {
                MainRawImage.gameObject.SetActive(false);
            }
            else
            {
                MainRawImage.gameObject.SetActive(true);
                MainRawImage.Init(GameHelper.GetImagePath(data.ImageName));
            }

            GoodText.text = data.PraiseCountStr.ToString();
            CommentText.text = data.CommentCount.ToString();
        }

        public void OnClickEditButton()
        {
            if (!EditPostButtonView.IsShow())
            {
                EditPostButtonView.Show(_index);
            }
            else
            {
                EditPostButtonView.Hide();
            }
        }

        private void OnClickCommentBtn()
        {
            Page.Instance.ShowCommentView(_index);
        }
    }
}