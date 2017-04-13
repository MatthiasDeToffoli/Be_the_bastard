using Assets.Scripts.GameObjects;
using Assets.Scripts.Managers;
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

        override protected void Awake()
        {
            base.Awake();
            actions = new Dictionary<Vector2, Action>();

            actions.Add(new Vector2(9, 30), SetModeGoCofe);
            actions.Add(new Vector2(9, 45), SetModeGoWork);
            actions.Add(new Vector2(12, 20), GoToSleep);
            actions.Add(new Vector2(15, 0), SetModeGoToilet);
            actions.Add(new Vector2(15, 15), SetModeGoWork);
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
                agent.SetDestination(new Vector3(0.77f, 0.5f, -3.12f));
                doAction = DoActionGoAngry;
            } 
            else
            {
                if (!isInToilet)
                {
                    agent.SetDestination(workPos);
                    doAction = DoActionGoWork;
                }              
            }        
        }

        protected void DoActionGoAngry()
        {
            if (!agent.hasPath)
            {
                Debug.Log(name + "Cette putin de machine a café est en panne !");
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
                haveDrinkCoffee = false;
        }

        protected void GoToilet()
        {
            if (haveDrinkCoffee && !sleeping)
            {
                agent.SetDestination(GameObject.FindGameObjectWithTag(InteractiveName.TOILET).transform.position);
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