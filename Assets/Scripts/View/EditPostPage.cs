using System;
using DefaultNamespace.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class EditPostPage : MonoBehaviour
    {
        public InputField TimeInputField;
        public InputField ContentInputField;
        public InputField PraiseCountInputField;
        public InputField CommentCountInputField;
        public Button SelectImage;
        public Button RemoveImage;
        public Button SaveBtn;
        public Button ExitBtn;
        public RawImage ShowImage;

        private string _imageName;
        private bool _isNew;
        private PostData _data;

        public void InitUI()
        {
            SelectImage.onClick.AddListener(OnClickSelectImage);
            RemoveImage.onClick.AddListener(OnClickRemoveImage);
            SaveBtn.onClick.AddListener(OnClickSave);
            ExitBtn.onClick.AddListener(OnClickExit);
            
            gameObject.SetActive(false);
        }

        public void OnOpen(bool isNew, PostData data)
        {
            _isNew = isNew;
            _data = data;
            _imageName = _data.ImageName;
            Refresh();
            gameObject.SetActive(true);
        }

        private void Refresh()
        {
            if (!string.IsNullOrEmpty(_data.ImageName))
            {
                ShowImage.texture = RawManager.Instance.LoadSaveImage(GameHelper.GetImagePath(_data.ImageName));
            }
            else
            {
                ShowImage.texture = null;
            }
            TimeInputField.text = _data.Time;
            ContentInputField.text = _data.Content;
            PraiseCountInputField.text = _data.PraiseCount.ToString();
            CommentCountInputField.text = _data.CommentCount.ToString();
        }

        private void OnClickSave()
        {
            _data.ImageName = _imageName;
            _data.PraiseCount = int.Parse(PraiseCountInputField.text);
            _data.CommentCount = int.Parse(CommentCountInputField.text);
            _data.Time = TimeInputField.text;
            _data.Content = ContentInputField.text;

            if (_isNew)
            {
                var userData = UserManager.Instance.GetUserData();
                userData.Posts.Add(_data);
            }
            
            UserManager.Instance.Save();
            
            Page.Instance.Refresh();
            gameObject.SetActive(false);
        }

        private void OnClickExit()
        {
            gameObject.SetActive(false);
        }

        private void OnClickSelectImage()
        {
            var fileName = Guid.NewGuid().ToString() + ".png";
            
            var path = GameHelper.GetImagePath(fileName);
            RawManager.Instance.PickImage(path, tex =>
            {
                _imageName = fileName;
                ShowImage.texture = tex;
            });
        }

        private void OnClickRemoveImage()
        {
            _imageName = "";
            ShowImage.texture = null;
        }
    }
}