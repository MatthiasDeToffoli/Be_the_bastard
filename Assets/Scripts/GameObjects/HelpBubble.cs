using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

namespace Assets.Scripts.GameObjects
{

    /// <summary>
    /// 
    /// </summary>
    public class HelpBubble : MonoBehaviour
    {

        private static HelpBubble _instance;

        protected Text myText;
        protected Boolean isMessageWrited = false;

        protected const string TEXT1 = "J'ai un peu de temps avant que les autres arrivent. \n Comment pourrais-je frainer l'avancée du projet?";
        protected const string TEXT2 = "Ils sont là ! faisons comme si de rien n'était.";
        protected const string TEXT3 = "Il ne me reste plus beaucoup de temps. Il faut que je trouve autre chose.";


        public float letterPause = 0.2f;
        string message = "J'ai un peu de temps avant que les autres arrivent. \n Comment pourrais-je frainer l'avancée du projet?";

        /// <summary>
        /// instance unique de la classe     
        /// </summary>
        public static HelpBubble instance
        {
            get
            {
                return _instance;
            }
        }

        protected void Awake()
        {
            if (_instance != null)
            {
                throw new Exception("Tentative de création d'une autre instance de HelpBubble alors que c'est un singleton.");
            }
            _instance = this;
        }

        protected void Start()
        {
            myText = GetComponent<Text>();
            ChangeText(TEXT1);
        }

        // fonction d'animation d'écriture
        IEnumerator TypeText()
        {
            foreach (char letter in message.ToCharArray())
            {
                myText.text += letter;
                if (myText.text == message)
                {
                    isMessageWrited = true;
                }
                /*if (typeSound1 && typeSound2)
                    SoundManager.instance.RandomizeSfx(typeSound1, typeSound2);*/
                yield return 0;
                yield return new WaitForSeconds(letterPause);
            }
        }
    

        protected void Update()
        {

        }

        protected void OnDestroy()
        {
            _instance = null;
        }

        // fonction à appeler pour changer le contenu du message
        protected void ChangeText(string pText)
        {
            myText.text = pText;
            message = myText.text;
            myText.text = "";
            StartCoroutine(TypeText());    
        }

        // Fermer le cadre quand le message est écrit
         public void OnMouseDown()
        {
            if (isMessageWrited)
            {
                _instance.gameObject.SetActive(false);
                ChangeText(TEXT2);
            }
        }
    }
}