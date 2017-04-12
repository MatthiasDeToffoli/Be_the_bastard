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

        private GameObject objClicked;

        private Vector3 pos;
        private Animation anim;
        private Action doAction;
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

            pos = Vector3.zero;
        }

        protected void Start()
        {
            agent = GetComponent<NavMeshAgent>();

            anim = GetComponent<Animation>();
            SetModeVoid();
            //agent.SetDestination(new Vector3(5, 0, 0));
        }

        protected void Update()
        {
            doAction();

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    agent.SetDestination(hit.point);

                    objClicked = GameObject.Find(hit.transform.name);
                }          

                    SetModeMove();
                    
                }      

         }

        protected void SetModeVoid()
        {
            doAction = DoActionVoid;
        }

        protected void DoActionVoid()
        {

        }

        protected void DoActionMove()
        {
            if (!agent.hasPath)
            {
                if(objClicked.transform.tag != "bubblePlane")
                {
                    Vector3 roundTargetPos = new Vector3(objClicked.transform.position.x, 0, objClicked.transform.position.z);
                    Vector3 roundAgentPos = new Vector3(transform.position.x, 0, transform.position.z);
                    transform.rotation = Quaternion.LookRotation(roundTargetPos - roundAgentPos);
                }
                
                anim.Play("sleep");
                SetModeVoid();
            }
        }

        protected void SetModeMove()
        {
            anim["walk"].speed = 4f;
            anim.wrapMode = WrapMode.Loop;
            anim.Play("walk");

            doAction = DoActionMove;
        }

        protected void OnDestroy()
        {
            _instance = null;
        }
    }
}