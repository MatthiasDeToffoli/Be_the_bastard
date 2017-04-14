using Com.IsartDigital.BeTheBastard.Scripts.Email;
using Com.IsartDigital.BeTheBastard.Scripts.UI;
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

        //Answer Choice
        [SerializeField]
        protected Text choice1;
        [SerializeField]
        protected Text choice2;
        [SerializeField]
        protected Text choice3;

        protected UIBar bar;

        protected const float BONUS = 0.05f;
        protected const float MALUS = 0.2f;

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

        protected void Start()
        {
            bar = GameObject.FindGameObjectWithTag("chaos").GetComponent<UIBar>();
        }

        void Awake()
        {
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
            if (NumChoice == 1) Choice1();
            if (NumChoice == 2) Choice2();
            if (NumChoice == 3) Choice3();
        }
    #endregion
    #region AnswerAction
        //Choice who impact the discretion 
        protected void Choice1()
        {
            bar.UnFill(MALUS);
            Debug.Log("Choice1");
        }

        //Choice who impact nothing
        protected void Choice2()
        {
            bar.Fill(0);
            Debug.Log("Choice2");
        }

        //Choice who impact chaos
        protected void Choice3()
        {
            bar.Fill(BONUS);
            Debug.Log("Choice3");
        }
    #endregion

        private Emails() {}

        public void Dispose()
        {
            _instance = null;
        }
    }
}