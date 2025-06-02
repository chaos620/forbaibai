using System;
using UnityEngine;

namespace DefaultNamespace.Manager
{
    public class UserManager : Singleton<UserManager>
    {
        private const string SaveKey = "UserData";
        private UserData _userData;

        public void Init()
        {
            Load();
        }

        private void Save()
        {
            var json = JsonUtility.ToJson(_userData);
            PlayerPrefs.SetString(SaveKey, json);
            PlayerPrefs.Save();
        }

        public UserData GetUserData()
        {
            return _userData;
        }

        public void SetUserInfo(string name, string nameTitle, string title, string signature)
        {
            _userData.Name = name;
            _userData.Title = title;
            _userData.NameTitle = nameTitle;
            _userData.Signature = signature;
            Save();
        }

        private void Load()
        {
            var json = PlayerPrefs.GetString(SaveKey);
            try
            {
                _userData = JsonUtility.FromJson<UserData>(json);

                if (_userData == null)
                {
                    _userData = new UserData();
                }
            }
            catch (Exception e)
            {
                _userData = new UserData();
            }
            
        }
    }
}