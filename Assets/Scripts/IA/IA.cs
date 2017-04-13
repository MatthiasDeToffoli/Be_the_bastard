using Assets.Scripts.GameObjects;
using Assets.Scripts.Managers;
using Assets.Scripts.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public enum BaseAction { TOILET, DIST, COFE };

namespace Com.IsartDigital.Assets.Scripts.IA
{
    public class IA : MonoBehaviour
    {
        protected bool sleeping = false;
        protected bool isInToilet = false;

        protected NavMeshAgent agent;
        protected Animation anim;
        protected Dictionary<Vector2, Action> actions;

        [SerializeField]
        protected Vector3 workPos;
        [SerializeField]
        protected GameObject workTable;
            
        protected Action doAction;
        protected string actualPosition;

        virtual protected void Awake()
        {
            SetModeVoid();
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animation>();
            actualPosition = "working";
        }

        //work action
        virtual protected void SetModeGoWork()
        {
            anim["walk"].speed = 4f;
            anim.wrapMode = WrapMode.Loop;
            anim.Play("walk");

            agent.SetDestination(workPos);
            doAction = DoActionGoWork;
        }

        virtual protected void DoActionGoWork()
        {
            HavePathAction(workTable.transform.position);
        }

        //void action
        virtual protected void SetModeVoid()
        {
            doAction = DoActionVoid;
        }

        virtual protected void DoActionVoid()
        {

        }

        //move action
        virtual protected void SetModeMove()
        {
            Move();
            doAction = DoActionMove;
        }

        virtual protected void DoActionMove()
        {
            HavePathAction(Vector3.zero);
        }

        //toilet action
        virtual protected void SetModeGoToilet()
        {
            Move();
            agent.SetDestination(GameObject.FindGameObjectWithTag(InteractiveName.TOILET).transform.position);
            doAction = DoActionGoToilet;
        }

        virtual protected void DoActionGoToilet()
        {
            HavePathAction(GameObject.FindGameObjectWithTag(InteractiveName.TOILET).transform.position);
        }

        //cofe machine action
        virtual protected void SetModeGoCofe()
        {
            Move();
            agent.SetDestination(GameObject.FindGameObjectWithTag(InteractiveName.COFE).transform.position);
            doAction = DoActionGoCofe;
        }

        virtual protected void DoActionGoCofe()
        {
            HavePathAction(GameObject.FindGameObjectWithTag(InteractiveName.COFE).transform.position);
        }

        //Distrib action
        virtual protected void SetModeGoDistrib()
        {
            Move();
            agent.SetDestination(GameObject.FindGameObjectWithTag(InteractiveName.DISTRIB).transform.position);
            doAction = DoActionGoDistrib;
        }

        virtual protected void DoActionGoDistrib()
        {
            HavePathAction(GameObject.FindGameObjectWithTag(InteractiveName.DISTRIB).transform.position);
        }


        virtual protected void SetModeBibli()
        {
            Move();
            if(!ClickableManager.manager.isAllwaysClicked(ClickableManager.CHAIR))
            {
                agent.SetDestination(GameObject.FindGameObjectWithTag(InteractiveName.BIBLI).transform.position);
                doAction = DoActionBibli;
            } else
            {
                agent.SetDestination(GameObject.FindGameObjectWithTag(InteractiveName.CHAIR).transform.position);
                doAction = DoActionGoTableBeforeBibli;
            }
            

        }

        virtual protected void DoActionBibli()
        {
            HavePathAction(GameObject.FindGameObjectWithTag(InteractiveName.BIBLI).transform.position);
        }

        protected void DoActionGoTableBeforeBibli()
        {
            HavePathAction(GameObject.FindGameObjectWithTag(InteractiveName.CHAIR).transform.position);
        }

        virtual protected void SetModePanic()
        {
            doAction = doActionPanic;
        }

        protected void doActionPanic() { }

        //sleep action
        virtual protected void SetModeSleep()
        {
            doAction = DoActionSleep;
        }

        virtual protected void DoActionSleep()
        {

        }

        //waiting actions
        virtual protected void SetModeIsAtCofe()
        {
            doAction = IsAtCofe;
        }

        virtual protected void IsAtCofe()
        {
            
        }

        virtual protected void SetModeIsInToilet()
        {
            doAction = IsAtToilet;
        }

        virtual protected void IsAtToilet()
        {
            isInToilet = true;
        }

        virtual protected void SetModeIsAtDistrib()
        {
            doAction = IsAtDistrib;
        }

        virtual protected void IsAtDistrib()
        {
             
        }

        //General action
        void Update()
        {
            doAction();
            checkHour(HourInfo.getHour());          
        }

        protected void Move()
        {
            anim["walk"].speed = 4f;
            anim.wrapMode = WrapMode.Loop;
            anim.Play("walk");
        }

        protected void HavePathAction(Vector3 targetPos)
        {
            if (!agent.hasPath)
            {
                if (targetPos != Vector3.zero)
                {
                    Vector3 roundTargetPos = new Vector3(targetPos.x, 0, targetPos.z);
                    Vector3 roundAgentPos = new Vector3(transform.position.x, 0, transform.position.z);
                    transform.rotation = Quaternion.LookRotation(roundTargetPos - roundAgentPos);
                }

                if (targetPos == GameObject.FindGameObjectWithTag(InteractiveName.DISTRIB).transform.position) SetModeIsAtDistrib();
                else if (targetPos == GameObject.FindGameObjectWithTag(InteractiveName.COFE).transform.position) SetModeIsAtCofe();
                else if (targetPos == GameObject.FindGameObjectWithTag(InteractiveName.TOILET).transform.position) SetModeIsInToilet();
                else if(targetPos == GameObject.FindGameObjectWithTag(InteractiveName.CHAIR).transform.position) SetModePanic();
                else {
                    SetModeVoid();
                }
            
            }
        }

        protected void checkHour(Vector2 pHour)
        {
            if (actions.ContainsKey(pHour)) {
                actions[pHour]();
            }
        }
    }
}
