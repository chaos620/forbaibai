using System;
using DefaultNamespace.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class EditCommentPage : MonoBehaviour
    {
        public InputField NameInputField;
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
        private CommentData _data;
        private PostData _postData;

        public void InitUI()
        {
            SelectImage.onClick.AddListener(OnClickSelectImage);
            RemoveImage.onClick.AddListener(OnClickRemoveImage);
            SaveBtn.onClick.AddListener(OnClickSave);
            ExitBtn.onClick.AddListener(OnClickExit);
            
            gameObject.SetActive(false);
        }

        public void OnOpen(bool isNew, PostData postData, CommentData data)
        {
            _isNew = isNew;
            _postData = postData;
            _data = data;
            _imageName = _data.Avatar;
            Refresh();
            gameObject.SetActive(true);
        }

        private void Refresh()
        {
            if (!string.IsNullOrEmpty(_data.Avatar))
            {
                ShowImage.texture = RawManager.Instance.LoadSaveImage(GameHelper.GetImagePath(_data.Avatar));
            }
            else
            {
                ShowImage.texture = null;
            }
            NameInputField.text = _data.Name;
            ContentInputField.text = _data.Content;
            PraiseCountInputField.text = _data.PraiseCountStr;
            CommentCountInputField.text = _data.CommentCount.ToString();
        }

        private void OnClickSave()
        {
            _data.Avatar = _imageName;
            _data.PraiseCountStr = PraiseCountInputField.text;
            _data.CommentCount = int.Parse(CommentCountInputField.text);
            _data.Name = NameInputField.text;
            _data.Content = ContentInputField.text;

            if (_isNew)
            {
                _postData.Comments.Add(_data);
            }
            
            UserManager.Instance.Save();
            
            Page.Instance.RefreshComment(_postData);
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