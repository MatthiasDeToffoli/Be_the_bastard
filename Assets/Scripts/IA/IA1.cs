using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.Assets.Scripts.IA
{
    /// <summary>
    /// 
    /// </summary>
    public class IA1 : IA
    {
        override protected void Awake()
        {
            base.Awake();
            actions = new Dictionary<Vector2, Action>();
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