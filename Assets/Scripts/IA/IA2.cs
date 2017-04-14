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
    public class IA2 : IA
    {
        protected bool haveDrinkCoffee = false;
        protected bool haveCry = false;
        protected bool haveFillForCry = false;

        override protected void Awake()
        {
            base.Awake();
            actions = new Dictionary<Vector2, Action>();

            actions.Add(new Vector2(10, 15), SetModeGoCofe);
            actions.Add(new Vector2(11, 0), SetModeGoWork);
            actions.Add(new Vector2(11, 50), GoToSleep);
            actions.Add(new Vector2(15, 0), GoToilet);
            actions.Add(new Vector2(15, 30), SetModeGoWork);
        }

        protected void GoToSleep()
        {
            if (!haveDrinkCoffee)
            {
                anim.Play("sleep");
                sleeping = true;
                SetModeSleep();
            }
        }

        protected override void SetModeGoWork()
        {
            anim["walk"].speed = 4f;
            anim.wrapMode = WrapMode.Loop;
            anim.Play("walk");

            if (!haveDrinkCoffee && !haveCry)
            {
                agent.SetDestination(new Vector3(0.78f, 0f, 14.16f));
                doAction = DoActionGoAngry;
            } 
            else
            {
                if (isInToilet)
                {
                    if (!ClickableManager.manager.isAllwaysClicked(ClickableManager.DOOR))
                    {
                        base.SetModeGoWork();
                    }
                }
                else
                {
                    base.SetModeGoWork();
                }
            }        
        }

        protected void DoActionGoAngry()
        {
            if (!agent.hasPath)
            {
                if (!haveFillForCry)
                {
                    haveFillForCry = true;
                    UIBar.instance.Fill(0.3f);
                }

                anim.Play("sleep");
                SetModeVoid();
                StartCoroutine(WaitAndGoWork());
            }
        }



        protected override void IsAtCofe()
        {
            if (!ClickableManager.manager.isAllwaysClicked(ClickableManager.COFFEE))
            {
                

                ClickableManager.manager.mate2HaveDrink = true;
                haveDrinkCoffee = true;
            }
            else
            {
                haveDrinkCoffee = false;
            }
        }

        protected void GoToilet()
        {
            if (haveDrinkCoffee && !sleeping)
            {
                agent.SetDestination(GameObject.FindGameObjectWithTag(InteractiveName.DOOR).transform.position);
                SetModeGoToilet();
            }
        }

        IEnumerator WaitAndGoWork()
        {
            yield return new WaitForSeconds(2);
            haveCry = true;
            SetModeGoWork();
        }
    }
}