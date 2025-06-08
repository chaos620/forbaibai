using DefaultNamespace.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UserView : MonoBehaviour
    {
        public GameRawImage HeadImage;
        public GameRawImage Avatar;
        public Text Name;
        public Text NameTitle;
        public Text Title;
        public Text Sign;

        public void Refresh()
        {
            HeadImage.Init(GameHelper.GetHeadPath());
            Avatar.Init(GameHelper.GetAvatarPath());

            var data = UserManager.Instance.GetUserData();

            Name.text = $"<b>{data.Name}</b>";
            NameTitle.text = data.NameTitle;
            Title.text = data.Title;
            Sign.text = data.Signature;
        }
    }
}