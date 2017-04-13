using System;
using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.Assets.Scripts.IA
{
    /// <summary>
    /// 
    /// </summary>
    public class IA6 : IA
    {
        override protected void Awake()
        {
            base.Awake();
            actions = new Dictionary<Vector2, Action>();

            actions.Add(new Vector2(9, 37), SetModeGoWork);
            actions.Add(new Vector2(11, 30), GoSleep);
        }

        protected void GoSleep()
        {
            anim.Play("sleep");
            sleeping = true;
            SetModeSleep();
        }


    }
}