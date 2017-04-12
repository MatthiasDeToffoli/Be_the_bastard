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

        protected Action doAction;

        virtual protected void Awake()
        {
            SetModeVoid();
            agent = GetComponent<NavMeshAgent>();
            anim = GetComponent<Animation>();
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

        void Update()
        {
            doAction();
            checkHour(HourInfo.getHour());          
        }

        protected void checkHour(Vector2 pHour)
        {
            if (actions.ContainsKey(pHour)) {
                actions[pHour]();
            }
        }
    }
}
