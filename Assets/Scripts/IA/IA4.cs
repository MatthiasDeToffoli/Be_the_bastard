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
    public class IA4 : IA
    {
        override protected void Awake()
        {
            base.Awake();
            actions = new Dictionary<Vector2, Action>();

            actions.Add(new Vector2(9, 35), SetModeGoWork);
            actions.Add(new Vector2(11, 0), SetModeGoToilet);
            actions.Add(new Vector2(11, 30), SetModeGoWork);
        }

        protected override void SetModeGoWork()
        {
            if (isInToilet)
            {
                
            }
            else
            {
                base.SetModeGoWork();
            }
        }

    }
}