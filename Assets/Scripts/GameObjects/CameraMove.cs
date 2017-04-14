using UnityEngine;
using System;
using Assets.Scripts.GameObjects.Player;

namespace Assets.Scripts.GameObjects
{

    /// <summary>
    /// 
    /// </summary>
    public class CameraMove : MonoBehaviour
    {

        private static CameraMove _instance;
        protected GameObject player;       //Public variable to store a reference to the player game object


        private Vector3 offset;         //Private variable to store the offset distance between the player and camera

        /// <summary>
        /// instance unique de la classe     
        /// </summary>
        public static CameraMove instance
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
                throw new Exception("Tentative de création d'une autre instance de Camera alors que c'est un singleton.");
            }
            _instance = this;
        }

        protected void Start()
        {
            player = PlayerAgent.instance.gameObject;
            offset = transform.position - player.transform.position;
        }

        void LateUpdate()
        {
            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            transform.position = player.transform.position + offset;
        }

        protected void OnDestroy()
        {
            _instance = null;
        }
    }
}