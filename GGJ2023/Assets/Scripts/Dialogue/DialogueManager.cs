using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CrabNine
{
     public class DialogueManager : Singleton<DialogueManager>
    {
        [SerializeField] bool isOpen;
        [SerializeField] bool isContinuing;
        [SerializeField] int currentQuote;

        List<Quotes> quotes;

        [SerializeField] string currentText = "";
        [SerializeField] float delay = 0.1f;
        [SerializeField] float endDelay = 1f;
        [Header("UI")]
        [SerializeField] GameObject dialogueGO;
        [SerializeField] TextMeshProUGUI quoteText;

       


       
        private void Update()
        {
            quoteText.text = currentText;

            if (Input.GetKeyDown(KeyCode.Space) && !CameraManager.Instance.LevelIsChanging)
            {
                InteractWithDialogue();
            }
        }
        IEnumerator StartDialogue(Quotes quote)
        {
            var _quoteDelay = delay;
            if (quote.quoteDelay > 0) _quoteDelay = quote.quoteDelay;


           

            //SoundManager.Instance.PlayOneShot(additionalDialogueAudioSource,quote.additionalCustomSFX);
            
            isContinuing = true;
            
            for (int i = 0; i < quote.quote.Length + 1; i++)
            {
                currentText = quote.quote.Substring(0, i);
                SetDialogueSound(quote);

                yield return new WaitForSeconds(_quoteDelay);
            }
            
            isContinuing = false;
            yield return new WaitForSeconds(endDelay);
            
        }
        /// <summary>
        /// Starts the Dialogue on UI
        /// </summary>
        public void TakeQuote(List<Quotes> quoteLists)
        {
            isOpen = true;
            quotes = quoteLists;

            dialogueGO.SetActive(true);
            StartCoroutine(StartDialogue(quotes[currentQuote]));
        }

        /// <summary>
        /// Closes the Dialogue or Skips the Quote
        /// </summary>
        public void InteractWithDialogue()
        {
            if (isOpen) 
            {
                if (!isContinuing)
                {
                    currentQuote++;

                    if (currentQuote < quotes?.Count)
                    {
                        StartCoroutine(StartDialogue(quotes[currentQuote]));
                    }
                    else
                    {

                        CameraManager.Instance.ChangeCamera();
                        currentQuote = 0;
                        


                    }
                }
                else
                {
                    StopAllCoroutines();
                    currentText = quotes[currentQuote].quote;
                    isContinuing = false;
                }
                
                
            }
           
        }

        public void ClearText() => quoteText.text = "";

        void SetDialogueSound(Quotes quote) 
        {
            //if (currentText.Length > 1 && currentText[currentText.Length - 1] != ' ')
                //SoundManager.Instance.PlayOneShot(dialogueAudioSource, quote.character.CharSoundEffect(quote));
        }
    }
}
