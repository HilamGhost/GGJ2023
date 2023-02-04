using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CrabNine
{
    public class PaintingCanva : MonoBehaviour
    {
        [SerializeField] private PaintingData[] paintingDatas;

        [SerializeField] private Image[] imageDatas;

        public void ChangePaintingData(int index,PaintingData _abstractWord)
        {
            paintingDatas[index].abstractName = _abstractWord.abstractName;
            paintingDatas[index].abstractImage = _abstractWord.abstractImage;
            paintingDatas[index].abstractText = _abstractWord.abstractText;

            
        }
        // Start is called before the first frame update
        protected  void Awake()
        {
            
            ApplyImages();
        }
        

        public void ApplyImages()
        {
            for (int i = 0; i < paintingDatas.Length; i++)
            {
               
                    if (paintingDatas[i].abstractImage == null)
                    {
                        imageDatas[i].enabled = false;
                    }
                    else
                    {
                        imageDatas[i].enabled = true;
                        imageDatas[i].sprite = paintingDatas[i].abstractImage;
                    }
                
            }
        }
        public void ClearCanvas(int _index)
        {

            paintingDatas[_index].abstractName = null;
            paintingDatas[_index].abstractImage = null;
            paintingDatas[_index].abstractText = null;
            ApplyImages();
            
        }
        
    }
}
