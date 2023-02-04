using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CrabNine
{
    [CreateAssetMenu(fileName = "New Narrative Part",menuName = "Create New Narrative Part")]
    public class NarrativePart : ScriptableObject
    {
        [SerializeField] private List<Quotes> quote;


        public List<Quotes> Quote => quote;
    }
}
