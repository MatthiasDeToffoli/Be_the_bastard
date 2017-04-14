using Assets.Scripts.GameObjects;
using Assets.Scripts.Managers;
using Com.IsartDigital.BeTheBastard.Scripts.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.Assets.Scripts.IA
{
    /// <summary>
    /// 
    /// </summary>
    public class IA5 : IA
    {
        protected bool haveFightForCoffee = false;

        override protected void Awake()
        {
            base.Awake();
            actions = new Dictionary<Vector2, Action>();

            actions.Add(new Vector2(9, 42), SetModeGoWork);
            actions.Add(new Vector2(15, 20), GoCofe);
            actions.Add(new Vector2(16, 5), SetModeGoWork);
        }

        protected override void SetModeGoWork()
        {
            if (ClickableManager.manager.mate2HaveDrink && ClickableManager.manager.isAllwaysClicked(ClickableManager.COFFEE))
            {
                if (haveFightForCoffee)
                {
                    base.SetModeGoWork();
                }
                else
                {
                    agent.SetDestination(new Vector3(-4f, 0f, 18.25f));
                    SetModeMove();
                }               
            }
            else
            {
                base.SetModeGoWork();
            }     
        }

        protected override void DoActionMove()
        {
            if (!agent.hasPath && ClickableManager.manager.mate2HaveDrink && ClickableManager.manager.isAllwaysClicked(ClickableManager.COFFEE))
            {
                anim.Play("fight");
                StartCoroutine(BimCoroutine());
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

        IEnumerator BimCoroutine()
        {
            yield return new WaitForSeconds(5);
            UIBar.instance.Fill(0.12f);
            haveFightForCoffee = true;
            SetModeGoWork();
        }

    }
}