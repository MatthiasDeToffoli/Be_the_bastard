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
    public class IA3 : IA
    {
        protected bool haveBuySomething = false;

        override protected void Awake()
        {
            base.Awake();
            actions = new Dictionary<Vector2, Action>();

            actions.Add(new Vector2(9, 36), SetModeGoWork);
            actions.Add(new Vector2(14, 0), GoDistrib);
            actions.Add(new Vector2(14, 30), SetModeGoWork);
            actions.Add(new Vector2(15, 0), SetModeSleep);
        }

        protected void GoDistrib()
        {
            agent.SetDestination(GameObject.FindGameObjectWithTag(InteractiveName.DISTRIB).transform.position);
            SetModeGoDistrib();
        }

        protected override void SetModeSleep()
        {
            if (!haveBuySomething)
            {
                anim.Play("Sleep");
                sleeping = true;
                base.SetModeSleep();
            }
        }

        protected override void IsAtDistrib()
        {
            if (!ClickableManager.manager.isAllwaysClicked(ClickableManager.DISTRIB))
            {
                haveBuySomething = true;
            }
            else
            {
                haveBuySomething = false;
            }
        }
    }
}