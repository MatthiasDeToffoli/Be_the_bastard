using Assets.Scripts.GameObjects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.Assets.Scripts.IA
{
    /// <summary>
    /// 
    /// </summary>
    public class IA2 : IA
    {
        override protected void Awake()
        {
            base.Awake();
            actions = new Dictionary<Vector2, Action>();

            actions.Add(new Vector2(9, 30), SetModeGoCofe);
            actions.Add(new Vector2(9, 45), SetModeGoWork);
            actions.Add(new Vector2(15, 0), GoToilet);
            actions.Add(new Vector2(15, 15), SetModeGoWork);
        }

        protected void GoToilet()
        {
            agent.SetDestination(GameObject.FindGameObjectWithTag(InteractiveName.TOILET).transform.position);
            SetModeGoToilet();
        }
    }
}