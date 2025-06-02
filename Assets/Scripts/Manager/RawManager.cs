using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Manager
{
    public class RawManager : Singleton<RawManager>
    {
        public Texture2D LoadImage(string path)
        {
            var ret = LoadSaveImage(path);
            return ret;
        }

        public void PickImage(string path, Action<Texture2D> callback)
        {
            NativeGallery.GetImageFromGallery(v =>
            {
                if (string.IsNullOrEmpty(v)) return;

                // 加载选中的图片
                var texture2D = LoadSelectedImage(v);

                if (texture2D != null)
                {
                    SaveAvatarToDisk(texture2D, path);
                }
                
                callback?.Invoke(texture2D);
            }, "选择图片", "image/*");
        }
        
        private Texture2D LoadSelectedImage(string path)
        {
            // 创建临时纹理
            Texture2D texture = NativeGallery.LoadImageAtPath(
                path, 
                1024,   // 限制最大尺寸
                false,          // 不标记为可读
                false           // 不生成mipmaps
            );

            if (texture == null)
            {
                Debug.LogError("加载图片失败: " + path);
                return null;
            }

            // 保存为新的纹理（确保可读）
            var ret = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
            ret.SetPixels(texture.GetPixels());
            ret.Apply();
            
            return texture;
        }
        
        private void SaveAvatarToDisk(Texture2D texture, string path)
        {
            if (texture == null) return;

            byte[] pngData = texture.EncodeToPNG();
            string filePath = path;
            
            var dir = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            
            File.WriteAllBytes(filePath, pngData);
            Debug.Log("头像已保存到: " + filePath);
        }
        
        public Texture2D LoadSaveImage(string path)
        {
            if (File.Exists(path))
            {
                var fileData = File.ReadAllBytes(path);
                var ret = new Texture2D(2, 2);
                ret.LoadImage(fileData);

                return ret;
            }

            return null;
        }
    }
}