using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrabNine
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        static T instance;
        public static T Instance => instance;
        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
            }
            else if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }

        private void OnDestroy()
        {
            instance = null;
        }
    }
}
