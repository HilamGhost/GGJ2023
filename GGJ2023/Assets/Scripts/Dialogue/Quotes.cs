using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrabNine
{
    [System.Serializable]
    public class Quotes
    {
        
        [Space(2)]
        [TextArea]
        public string quote;
        [Space]
        [Header("Custom Things")]
        public float quoteDelay;
        [Space]
        public bool hasCustomSFX;
        public AudioClip customQuoteSFX;
        

        [Header("Additional Things")]
        public AudioClip additionalCustomSFX;


    }
}
