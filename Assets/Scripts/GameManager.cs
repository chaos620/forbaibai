using System;
using DefaultNamespace.Manager;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            UserManager.Instance.Init();
        }
    }
}