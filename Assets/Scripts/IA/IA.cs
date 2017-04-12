using Assets.Scripts.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public enum BaseAction { TOILET, DIST, COFE };

public class BaseActionEvent : UnityEvent<BaseAction> { };

namespace Com.IsartDigital.Assets.Scripts.IA
{
    public class IA : MonoBehaviour
    {
        public static BaseActionEvent callAction = new BaseActionEvent();

        protected static Dictionary<Vector2, Action> actions = new Dictionary<Vector2, Action>();

        public static void init()
        {
            actions.Add(new Vector2(10, 5), GoToToilette);
            actions.Add(new Vector2(10, 40), GoToDistrib);
            actions.Add(new Vector2(12, 0), GoToCofe);
        }

        protected static void GoToToilette()
        {
            callAction.Invoke(BaseAction.TOILET);
        }

        protected static void GoToDistrib()
        {
            callAction.Invoke(BaseAction.DIST);
        }

        protected static void GoToCofe()
        {
            callAction.Invoke(BaseAction.COFE);
        }

        void Awake()
        {
            init();
        }

        void Update()
        {
            checkHour(HourInfo.getHour());          
        }

        void checkHour(Vector2 pHour)
        {
            if (actions.ContainsKey(pHour)) {
                actions[pHour]();
            }
        }
    }
}
