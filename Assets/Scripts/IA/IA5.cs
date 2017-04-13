using Assets.Scripts.GameObjects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.Assets.Scripts.IA
{
    /// <summary>
    /// 
    /// </summary>
    public class IA5 : IA
    {
        override protected void Awake()
        {
            base.Awake();
            actions = new Dictionary<Vector2, Action>();

            actions.Add(new Vector2(9, 51), SetModeGoWork);
            actions.Add(new Vector2(16, 0), GoCofe);
            actions.Add(new Vector2(16, 15), SetModeGoWork);
        }

        protected void GoCofe()
        {
            agent.SetDestination(GameObject.FindGameObjectWithTag(InteractiveName.COFE).transform.position);
            SetModeGoCofe();
        }

    }
}