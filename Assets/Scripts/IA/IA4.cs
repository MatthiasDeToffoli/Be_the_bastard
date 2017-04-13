using Assets.Scripts.GameObjects;
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

            actions.Add(new Vector2(9, 47), SetModeGoWork);
            actions.Add(new Vector2(12, 0), GoToilet);
            actions.Add(new Vector2(12, 15), SetModeGoWork);
        }

        protected void GoToilet()
        {
            agent.SetDestination(GameObject.FindGameObjectWithTag(InteractiveName.TOILET).transform.position);
            SetModeGoToilet();
        }

    }
}