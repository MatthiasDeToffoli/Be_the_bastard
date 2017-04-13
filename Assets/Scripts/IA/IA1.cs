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
    public class IA1 : IA
    {

        override protected void Awake()
        {
            base.Awake();
            actions = new Dictionary<Vector2, Action>();

             actions.Add(new Vector2(9, 30), SetModeBibli);
             actions.Add(new Vector2(10, 30), SetModeGoWork);
        }


        protected override void SetModePanic()
        {
            base.SetModePanic();
            GameObject.FindGameObjectWithTag(InteractiveName.CHAIR).GetComponent<ToDestroy>().fall();
        }



        protected void Start()
        {

        }

    }
}