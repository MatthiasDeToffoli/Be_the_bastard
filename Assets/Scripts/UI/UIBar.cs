using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.GameObjects.Player;
using System;

namespace Com.IsartDigital.BeTheBastard.Scripts.UI
{

    public class UIBar : MonoBehaviour
    {
        private static UIBar _instance;
        // Use this for initialization

        public static UIBar instance
        {
            get
            {
                return _instance;
            }
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
           
        }

        protected void Awake()
        {
            if (_instance != null)
            {
                throw new Exception("Tentative de création d'une autre instance de PlayerAgent alors que c'est un singleton.");
            }
            _instance = this;
        }

        public void CheckChaosBarState()
        {
            float chaosBarSize = GetComponent<Scrollbar>().size;
            if (chaosBarSize <= 0.33)
            {
                Debug.Log("je suis enervé"); // a changer par l'état graphique
                PlayerAgent.instance.mood = "angry";
            }
            else if (chaosBarSize > 0.33 && chaosBarSize <= 0.66)
            {
                Debug.Log("je suis neutre");// a changer par l'état graphique
                PlayerAgent.instance.mood = "neutral";
            }
            else
            {
                PlayerAgent.instance.mood = "happy";
                Debug.Log("je suis happy");// a changer par l'état graphique
            }
        }

        public void Fill(float pValue)
        {
            CheckChaosBarState();
            GetComponent<Scrollbar>().size += pValue;
        }

        public void UnFill(float pValue)
        {
            CheckChaosBarState();
            GetComponent<Scrollbar>().size -= pValue;
        }
    }
}
