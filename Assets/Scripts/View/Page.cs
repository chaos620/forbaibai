using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Page : MonoBehaviour
    {
        public static Page Instance;

        public UserView UserView;
        public EditUserPage EditUserPage;
        public Button EditUserInfo;
        public Button HideBtn;

        private void Awake()
        {
            Instance = this;
            
            EditUserPage.InitUI();
            
            EditUserInfo.onClick.AddListener(OnClickEditUserInfo);
        }

        private void Start()
        {
            EditUserPage.Init();
            
            Refresh();
        }

        public void OnClickEditUserInfo()
        {
            EditUserPage.gameObject.SetActive(true);
        }

        public void Refresh()
        {
            UserView.Refresh();
        }
    }
}