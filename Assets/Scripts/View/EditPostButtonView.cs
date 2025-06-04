using System;
using DefaultNamespace.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class EditPostButtonView : MonoBehaviour
    {
        public Button RemoveBtn;
        public Button EditBtn;

        private int _index;
        private void Awake()
        {
            RemoveBtn.onClick.AddListener(OnClickRemoveBtn);
            EditBtn.onClick.AddListener(OnClickEditBtn);
        }

        public void Show(int index)
        {
            _index = index;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public bool IsShow()
        {
            return gameObject.activeSelf;
        }
        private void OnClickRemoveBtn()
        {
            UserManager.Instance.GetUserData().Posts.RemoveAt(_index);
            UserManager.Instance.Save();
            Hide();
            Page.Instance.Refresh();
        }

        private void OnClickEditBtn()
        {
            var data = UserManager.Instance.GetUserData().Posts[_index];
            Page.Instance.EditPostPage.OnOpen(false, data);
            Hide();
        }
    }
}