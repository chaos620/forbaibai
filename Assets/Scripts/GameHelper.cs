using System.IO;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameHelper
    {
        public static string ImageFolder = Application.persistentDataPath + "/Images/";
        public const string AvatarFileName = "Avatar.png";
        public const string HeadFileName = "Head.png";

        public static string GetImagePath(string name)
        {
            return Path.Combine(ImageFolder, name);
        }

        public static string GetAvatarPath()
        {
            return GetImagePath(AvatarFileName);
        }

        public static string GetHeadPath()
        {
            return GetImagePath(HeadFileName);
        }
    }
}