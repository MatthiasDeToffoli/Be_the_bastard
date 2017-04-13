using Assets.Scripts.GameObjects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.Assets.Scripts.IA
{
    /// <summary>
    /// 
    /// </summary>
    public class IA3 : IA
    {
        override protected void Awake()
        {
            base.Awake();
            actions = new Dictionary<Vector2, Action>();

            actions.Add(new Vector2(9, 42), SetModeGoWork);
            actions.Add(new Vector2(14, 20), GoDistrib);
            actions.Add(new Vector2(14, 35), SetModeGoWork);
        }

        protected void GoDistrib()
        {
            agent.SetDestination(GameObject.FindGameObjectWithTag(InteractiveName.DISTRIB).transform.position);
            SetModeGoDistrib();
        }


    }
}