using Assets.Scripts.GameObjects;
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
        protected void SetModeGoWork()
        {
            anim["walk"].speed = 4f;
            anim.wrapMode = WrapMode.Loop;
            anim.Play("walk");

            agent.SetDestination(workPos);
            doAction = DoActionGoWork;
        }

        protected void DoActionGoWork()
        {
            HavePathAction(workTable.transform.position);
        }

        //void action
        protected void SetModeVoid()
        {
            doAction = DoActionVoid;
        }

        protected void DoActionVoid()
        {

        }

        //move action
        protected void SetModeMove()
        {
            Move();
            doAction = DoActionMove;
        }

        protected void DoActionMove()
        {
            HavePathAction(Vector3.zero);
        }

        //toilet action
        protected void SetModeGoToilet()
        {
            Move();
            agent.SetDestination(GameObject.FindGameObjectWithTag(InteractiveName.TOILET).transform.position);
            doAction = DoActionGoToilet;
        }

        protected void DoActionGoToilet()
        {
            HavePathAction(GameObject.FindGameObjectWithTag(InteractiveName.TOILET).transform.position);
        }

        //cofe machine action
        protected void SetModeGoCofe()
        {
            Move();
            agent.SetDestination(GameObject.FindGameObjectWithTag(InteractiveName.COFE).transform.position);
            doAction = DoActionGoCofe;
        }

        protected void DoActionGoCofe()
        {
            HavePathAction(GameObject.FindGameObjectWithTag(InteractiveName.COFE).transform.position);
        }

        //Distrib action
        protected void SetModeGoDistrib()
        {
            Move();
            agent.SetDestination(GameObject.FindGameObjectWithTag(InteractiveName.DISTRIB).transform.position);
            doAction = DoActionGoDistrib;
        }

        protected void DoActionGoDistrib()
        {
            HavePathAction(GameObject.FindGameObjectWithTag(InteractiveName.DISTRIB).transform.position);
        }

        //waiting actions
        protected void SetModeIsAtCofe()
        {
            doAction = IsAtCofe;
        }

        protected void IsAtCofe()
        {

        }

        protected void SetModeIsInToilet()
        {
            doAction = IsAtToilet;
        }

        protected void IsAtToilet()
        {

        }

        protected void SetModeIsAtDistrib()
        {
            doAction = IsAtDistrib;
        }

        protected void IsAtDistrib()
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

                anim.Play("sleep");
                SetModeVoid();
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
