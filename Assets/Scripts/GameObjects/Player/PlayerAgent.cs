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

        private Vector3 previousPosition;
        private Vector3 actualPosition;
        private GameObject objClicked;

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
            actualPosition = transform.position;
            previousPosition = transform.position;
        }

        protected void Update()
        {
            actualPosition = transform.position;
            if (actualPosition != previousPosition) {
                previousPosition = actualPosition;
            }
            else {
                if (objClicked && objClicked.transform.tag != "bubblePlane") {
                    Vector3 roundTargetPos = new Vector3(objClicked.transform.position.x, 0, objClicked.transform.position.z);
                    Vector3 roundAgentPos = new Vector3(transform.position.x, 0, transform.position.z);
                    transform.rotation = Quaternion.LookRotation(roundTargetPos - roundAgentPos);
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                /* Vector3 pos = Input.mousePosition;
                 pos.z = transform.position.z;
                 pos = Camera.main.ScreenToWorldPoint(pos);
                 Ray ray = new Ray(pos,Vector3.down);*/
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    agent.SetDestination(hit.point);
                    objClicked = GameObject.Find(hit.transform.name);
                }          
            }
        }

        protected void checkPlayerMovement()
        {

        }

        protected void OnDestroy()
        {
            _instance = null;
        }
    }
}