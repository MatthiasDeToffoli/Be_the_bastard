using UnityEngine;
using System;
using Assets.Scripts.Managers;

namespace Assets.Scripts.GameObjects
{

    /// <summary>
    /// 
    /// </summary>
    public class Horloge : MonoBehaviour
    {

        private static Horloge _instance;

        #region gameobjects 
        [SerializeField]
        protected GameObject aiguilleHeure;
        [SerializeField]
        protected GameObject aiguilleMinute;
        #endregion

        protected float minute = 0;
        protected float heure = 0;

        /// <summary>
        /// instance unique de la classe     
        /// </summary>
        public static Horloge instance
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
                throw new Exception("Tentative de création d'une autre instance de horloge alors que c'est un singleton.");
            }
            _instance = this;
        }

        protected void Start()
        {
            if (Metronome.instance)
            {
                Metronome.instance.onTic.AddListener(HeureRotation);
                Metronome.instance.interTic.AddListener(MinuteRotation);
            }
        }

        protected void Update()
        {

        }

        public void HeureRotation()
        {
            heure ++;
            aiguilleMinute.transform.rotation = Quaternion.Euler(0,0, -heure * 360/12);
        }

        public void MinuteRotation(float pMinutes)
        {
            aiguilleHeure.transform.rotation = Quaternion.Euler(0, 0, -pMinutes * 360 ); 
        }

        protected void OnDestroy()
        {
            _instance = null;
        }
    }
}