using Assets.Scripts.Managers;
using Assets.Scripts.Utils;
using Com.IsartDigital.BeTheBastard.Scripts.Email;
using Com.IsartDigital.BeTheBastard.Scripts.Managers;
using System;
using UnityEngine;

namespace Assets.Scripts.UI
{

    /// <summary>
    /// 
    /// </summary>
    public class UIMail : MonoBehaviour
    {
        protected Vector2 firstMailHour;
        protected Vector2 secondMailHour;
        protected Vector2 thirdMailHour;

        protected bool mail1received;
        protected bool mail2received;
        protected bool mail3received;

        #region Instance
        private static UIMail _instance;
        /// <summary>
        /// instance unique de la classe     
        /// </summary>
        public static UIMail instance
        {
            get
            {
                return _instance;
            }
        }
        #endregion

        protected void Awake()
        {
            if (_instance != null)
            {
                throw new Exception("Tentative de création d'une autre instance de UIMail alors que c'est un singleton.");
            }
            _instance = this;

            firstMailHour = new Vector2(9, 10);
            secondMailHour = new Vector2(14, 0);
            thirdMailHour = new Vector2(15, 20);

            mail1received = false;
            mail2received = false;
            mail3received = false;
        }

        protected void Start()
        {

        }

        protected void Update()
        {
            if (HourInfo.getHour() == firstMailHour)
            {
                if (!mail1received)
                {
                    mail1received = true;
                    MailBox.receiveMail(1);
                }
            }
            else if (HourInfo.getHour() == secondMailHour)
            {
                if (!mail2received)
                {
                    mail2received = true;
                    MailBox.receiveMail(2);
                }
            }
            else if (HourInfo.getHour() == thirdMailHour)
            {
                if (!mail3received)
                {
                    mail3received = true;
                    MailBox.receiveMail(3); 
                }
            }
        }


    }
}