using Assets.Scripts.GameObjects;
using Assets.Scripts.Managers;
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
            actions.Add(new Vector2(10, 20), GoCofe);
            actions.Add(new Vector2(10, 35), SetModeGoWork);
        }

        protected override void SetModeGoWork()
        {
            if (ClickableManager.manager.mate2HaveDrink && ClickableManager.manager.isAllwaysClicked(ClickableManager.COFFEE))
            {
                agent.SetDestination(new Vector3(1.91f, 0.5f, -4.38f));
                SetModeMove();
            }
            else
            {
                base.SetModeGoWork();
            }     
        }

        protected void GoCofe()
        {
            if (ClickableManager.manager.mate2HaveDrink)
            {
                agent.SetDestination(GameObject.FindGameObjectWithTag(InteractiveName.COFE).transform.position);
                SetModeGoCofe();
            }          
        }

    }
}