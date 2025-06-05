using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class CommentView : MonoBehaviour
    {
        public CommentItem CommentItemPrefab;
        public Button CloseBtn;
        public Button AddCommentBtn;
        public Text CommentCountText;
        public Transform Parent;

        private List<CommentItem> _commentItems = new List<CommentItem>();

        private PostData _postData;
        private void Awake()
        {
            CloseBtn.onClick.AddListener(OnClickCloseBtn);
            AddCommentBtn.onClick.AddListener(OnClickAddCommentBtn);

            gameObject.SetActive(false);
        }

        public void OnOpen(PostData data)
        {
            AddCommentBtn.gameObject.SetActive(!Page.Instance.IsHide);
            _postData = data;
            gameObject.SetActive(true);
            Refresh(data);
        }
        
        private void OnClickAddCommentBtn()
        {
            Page.Instance.OnClickAddComment(_postData);
        }

        private void OnClickCloseBtn()
        {
            gameObject.SetActive(false);
        }
        
        public void Refresh(PostData data)
        {
            RefreshItem(data);
            RefreshText(data);
        }

        private void RefreshItem(PostData data)
        {
            var comments = data.Comments;
            int i = 0;
            for (; i < comments.Count; i++)
            {
                if (i >= _commentItems.Count)
                {
                    var item = CreateOnePostItem();
                    _commentItems.Add(item);
                }
                
                _commentItems[i].gameObject.SetActive(true);
                _commentItems[i].Refresh(data, comments[i]);
            }

            for (; i < _commentItems.Count; i++)
            {
                _commentItems[i].gameObject.SetActive(false);
            }

            StartCoroutine(RefreshLayout());
        }

        private void RefreshText(PostData data)
        {
            CommentCountText.text = data.CommentCount.ToString();
        }

        private IEnumerator RefreshLayout()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(Parent as RectTransform);
            yield return new WaitForEndOfFrame();
            LayoutRebuilder.ForceRebuildLayoutImmediate(Parent as RectTransform);
        }

        private CommentItem CreateOnePostItem()
        {
            var ret = Instantiate(CommentItemPrefab, Parent);
            return ret;
        }
    }
}