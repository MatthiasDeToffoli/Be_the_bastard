using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets
{

    /// <summary>
    /// 
    /// </summary>
    public class Emails : Hud
    {

        private static Emails _instance;
        protected Emails[] emailList;
        protected string[] messageList = new string[3] { "Message 1", "Message2", "Message3" };
        protected string[] senderList = new string[6] { "People1", "People2", "People3", "People4", "People5", "People6" };
        [SerializeField]
        protected Text message;
        [SerializeField]
        protected Text sender;

        [SerializeField]
        protected Text choice1;
        [SerializeField]
        protected Text choice2;
        [SerializeField]
        protected Text choice3;

        public ChoiceEvent choiceBtn;

        /// <summary>
        /// instance unique de la classe     
        /// </summary>
        public static Emails instance
        {
            get
            {
                if (_instance == null) _instance = new Emails();
                return _instance;
            }
        }

        void Awake()
        {
            choiceBtn = new ChoiceEvent();
            EmailMessage();
            
        }

       
    #region EmailContent
        public String EmailMessage()
        {
            return SetMessage();
        }

        //Choose a random Email Message
        protected string SetMessage()
        {
            System.Random rnd = new System.Random();
            int randomMessage = rnd.Next(0, messageList.Length - 1);
            int randomSender = rnd.Next(0, senderList.Length - 1);
            sender.text = senderList[randomSender];
            return message.text = messageList[randomMessage];  
        }
        #endregion

    #region AnswerChoice
        public void Choice(int NumChoice)
        {
            if (NumChoice == 1) BadChoice();
            if (NumChoice == 2) MediumChoice();
            if (NumChoice == 3) GoodChoice();
        }
    #endregion
    #region AnswerAction
        //Choice who impact the discretion 
        protected void BadChoice()
        {
            Debug.Log("Bad Choice");
        }

        //Choice who impact nothing
        protected void MediumChoice()
        {
            Debug.Log("Medium Choice");
        }

        //Choice who impact chaos
        protected void GoodChoice()
        {
            Debug.Log("Good Choice");
        }
    #endregion

        private Emails() {}

        public void Dispose()
        {
            _instance = null;
        }
    }
}