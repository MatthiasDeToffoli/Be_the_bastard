using UnityEngine;
using System;
using UnityEngine.AI;
using Assets.Scripts.Managers;
using UnityEngine.EventSystems;
using Com.IsartDigital.BeTheBastard.Scripts.UI;
using Com.IsartDigital.BeTheBastard.Scripts.Email;

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

        public string playerType;

        public static bool isAnimDoor;


        public string mood; // Humeur du player
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
            MailBox.loadJson();
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
            
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
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
            anim.Play("idle");
            anim.wrapMode = WrapMode.Loop;
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
            SetModeVoid();
        }

        public void SetModeCoffee()
        {
            doAction = DoActionCoffee;
        }

        protected void DoActionCoffee()
        {
            Debug.Log("Café débranché");
            SetModeVoid();
        }

        public void SetModeDistrib()
        {
            doAction = DoActionDistrib;
        }

        protected void DoActionDistrib()
        {
            Debug.Log("Panneau sur le distrib");
            SetModeVoid();
        }

        public void SetModeDoor()
        {
            doAction = DoActionDoor;
        }

        protected void DoActionDoor()
        {
            Debug.Log("porte bloquée");
            SetModeVoid();
        }

        public void SetModeChair()
        {
            doAction = DoActionChair;
        }

        protected void DoActionChair()
        {
            Debug.Log("chaise sabotée");
            SetModeVoid();
        }

        protected void DoActionMove()
        {
            if (!agent.hasPath)
            {
                if(objClicked.transform.tag != "plane")
                {
                    Vector3 roundTargetPos = new Vector3(objClicked.transform.position.x, 0, objClicked.transform.position.z);
                    Vector3 roundAgentPos = new Vector3(transform.position.x, 0, transform.position.z);
                    transform.rotation = Quaternion.LookRotation(roundTargetPos - roundAgentPos);
                }

                 SetModeVoid();
                 ClickableManager.manager.OpenPanel();
            }
        }

        protected void SetModeMove()
        {
            anim["walk"].speed = 4f;
            anim.wrapMode = WrapMode.Loop;
            anim.Play("walk");

            ClickableManager.manager.SetObjectName();

            doAction = DoActionMove;
        }

        protected void OnDestroy()
        {
            _instance = null;
        }
    }
}