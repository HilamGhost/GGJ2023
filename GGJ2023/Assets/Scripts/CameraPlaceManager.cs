using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrabNine
{
    public class CameraPlaceManager : MonoBehaviour
    {
        public Transform textPosition;

        private void Start()
        {
            textPosition = GetComponentInChildren<Transform>();
            foreach (Transform _textTransform in textPosition)
            {
                if (_textTransform != transform)
                {
                    textPosition = _textTransform;
                    break;
                }
            }
        }
    }
}
