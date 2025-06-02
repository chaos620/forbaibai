using DefaultNamespace.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class EditUserPage : MonoBehaviour
    {
        public InputField NameInput;
        public InputField NameTitleInput;
        public InputField TitleInput;
        public InputField SignatureInput;
        public Button SelectAvatar;
        public Button SelectHead;

        public Button Save;
        public Button Exit;

        public void InitUI()
        {
            SelectAvatar.onClick.AddListener(OnClickSelectAvatar);
            SelectHead.onClick.AddListener(OnClickSelectHead);
            Save.onClick.AddListener(OnClickSave);
            Exit.onClick.AddListener(OnClickExit);
            
            gameObject.SetActive(false);
        }

        public void Init()
        {
            var data = UserManager.Instance.GetUserData();
            NameInput.text = data.Name;
            NameTitleInput.text = data.NameTitle;
            TitleInput.text = data.Title;
            SignatureInput.text = data.Signature;
        }

        public void OnClickSelectAvatar()
        {
            RawManager.Instance.PickImage(GameHelper.GetAvatarPath(), null);
        }

        public void OnClickSelectHead()
        {
            RawManager.Instance.PickImage(GameHelper.GetHeadPath(), null);
        }
        
        public void OnClickSave()
        {
            var name = NameInput.text;
            var nameTitle = NameTitleInput.text;
            var title = TitleInput.text;
            var signature = SignatureInput.text;
            
            UserManager.Instance.SetUserInfo(name, nameTitle, title, signature);
            
            Page.Instance.Refresh();
            gameObject.SetActive(false);
        }

        public void OnClickExit()
        {
            gameObject.SetActive(false);
        }
    }
}