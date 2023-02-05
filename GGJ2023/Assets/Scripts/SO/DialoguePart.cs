using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrabNine
{
    [CreateAssetMenu(fileName = "New Dialogue Part",menuName = "Create New Dialogue Part")]
    public class DialoguePart : ScriptableObject
    {
        [SerializeField] private List<Quotes> quote;


        public List<Quotes> Quote => quote;
    }
}
