using UnityEngine;
using System;
using UnityEngine.AI;
using Com.IsartDigital.BeTheBastard.Scripts.Clickable;
using Com.IsartDigital.Assets.Scripts.IA;

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

        public static bool isAnimDoor;
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

            IA.callAction.AddListener(dobaseAction);
        }

        public void dobaseAction(BaseAction actionCall) {
            switch(actionCall)
            {
                case BaseAction.TOILET: GoToilet(); break;
                case BaseAction.DIST: GoDistrib(); break;
                case BaseAction.COFE: GoCofe(); break;
                default: break;
            };
        }

        protected void GoToilet()
        {
            agent.SetDestination(GameObject.Find("Toilette").transform.position);
        }

        protected void GoDistrib()
        {
            agent.SetDestination(GameObject.Find("Distrib").transform.position);
        }

        protected void GoCofe()
        {
            agent.SetDestination(GameObject.Find("Cofe").transform.position);
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
                    SetModeMove();
                }          

                    
                    
                }      

         }

        protected void SetModeVoid()
        {
            doAction = DoActionVoid;
        }

        protected void DoActionVoid()
        {

        }
        
        public void SetModeClim()
        {
            doAction = DoActionClim;
        }

        protected void DoActionClim()
        {
            Debug.Log("Clim activée");
        }

        public void SetModeDoor()
        {
            doAction = DoActionDoor;
        }

        protected void DoActionDoor()
        {
            Debug.Log("porte bloquée");
        }

        public void SetModeChair()
        {
            doAction = DoActionChair;
        }

        protected void DoActionChair()
        {
            Debug.Log("chaise sabotée");
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