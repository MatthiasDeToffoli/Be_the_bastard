using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;
using Assets.Scripts.Utils;
using Assets.Scripts.GameObjects;

public class TempoEvent : UnityEvent<float> { };

namespace Assets.Scripts.Managers
{
    public class Metronome : MonoBehaviour
    {
        #region Tempo properties
        [SerializeField]
        private int tempo;
        private int l_tempo;

        private float totalTime;
        private float movingTime;

        private int minSpeed = 1;
        private int maxSpeed = 100;
        #endregion

        #region Time marker
        public UnityEvent onTic;
        public TempoEvent interTic;
        #endregion

        #region Instance
        private static Metronome _instance;
        /// <summary>
        /// instance unique de la classe     
        /// </summary>
        public static Metronome instance
        {
            get
            {
                return _instance;
            }
        }
        #endregion

        void Awake()
        {
            if (_instance != null)
            {
                throw new Exception("Tentative de création d'une autre instance de BoxManager alors que c'est un singleton.");
            }
            _instance = this;

            onTic = new UnityEvent();
            interTic = new TempoEvent();
        }

        // Use this for initialization
        void Start()
        {
            if (tempo < minSpeed) l_tempo = minSpeed;
            else if (tempo > maxSpeed) l_tempo = maxSpeed;
            else l_tempo = tempo;

            totalTime = 0;
            movingTime = 0;
        }

        void Update()
        {
            // Period calcul
            totalTime = l_tempo * maxSpeed / 100;

            // Poucentage in the time period
            movingTime += Time.deltaTime;

            // Poucentage of time period
            float percent = movingTime / totalTime;

            if (movingTime >= totalTime) {
                movingTime = 0;
                HourInfo.hours++;
                if (HourInfo.hours == 12)
                {
                    HourInfo.hours += 2;
                    Horloge.heure += 2;
                }
                onTic.Invoke();
            }
            else {
                HourInfo.minutes = Mathf.FloorToInt(percent * 60);
                interTic.Invoke(percent);
            }
        }

    }

}
