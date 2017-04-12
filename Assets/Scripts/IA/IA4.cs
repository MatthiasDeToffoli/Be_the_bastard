using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.Assets.Scripts.IA
{
    /// <summary>
    /// 
    /// </summary>
    public class IA4 : IA
    {
        override protected void Awake()
        {
            base.Awake();
            actions = new Dictionary<Vector2, Action>();

            actions.Add(new Vector2(9, 30), Arrive);
            actions.Add(new Vector2(10, 0), Cafe);
            actions.Add(new Vector2(10, 10), Arrive);
        }

        protected void Arrive()
        {
            agent.SetDestination(workPos);
            SetModeMove();
        }

        protected void Cafe()
        {
            agent.SetDestination(GameObject.FindGameObjectWithTag("Cafe").transform.position);
            SetModeMove();
        }

        protected void Start()
        {

        }

    }
}