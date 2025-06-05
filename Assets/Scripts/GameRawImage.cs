using System;
using DefaultNamespace.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameRawImage : MonoBehaviour
    {
        private RawImage _image;

        private void Awake()
        {
            _image = GetComponent<RawImage>();
        }

        public void Init(string path)
        {
            var tex = RawManager.Instance.LoadSaveImage(path);
            if (tex != null)
            {
                GetComponent<RawImage>().texture = tex;
            }
        }

        public void Clear()
        {
            _image.texture = null;
        }
    }
}