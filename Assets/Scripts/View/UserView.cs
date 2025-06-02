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

            Name.text = data.Name;
            NameTitle.text = data.Name;
            Title.text = data.Name;
            Sign.text = data.Signature;
        }
    }
}