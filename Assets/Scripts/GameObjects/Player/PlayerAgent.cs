using UnityEngine;
using System;
using UnityEngine.AI;

namespace Assets.Scripts.GameObjects.Player
{

    /// <summary>
    /// 
    /// </summary>
    public class PlayerAgent : MonoBehaviour
    {

        private static PlayerAgent _instance;
        private NavMeshAgent agent;
        /// <summary>
        /// instance unique de la classe     
        /// </summary>
        public static PlayerAgent instance
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
                throw new Exception("Tentative de création d'une autre instance de PlayerAgent alors que c'est un singleton.");
            }
            _instance = this;
        }

        protected void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            //agent.SetDestination(new Vector3(5, 0, 0));
        }

        protected void Update()
        {

            if (Input.GetMouseButtonDown(0))
            {
                /* Vector3 pos = Input.mousePosition;
                 pos.z = transform.position.z;
                 pos = Camera.main.ScreenToWorldPoint(pos);
                 Ray ray = new Ray(pos,Vector3.down);*/
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                    agent.SetDestination(hit.point);
            }
        }

        protected void OnDestroy()
        {
            _instance = null;
        }
    }
}