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

        public void Refresh(PostData data)
        {
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

            GoodText.text = data.PraiseCount.ToString();
            CommentText.text = data.CommentCount.ToString();
        }
    }
}