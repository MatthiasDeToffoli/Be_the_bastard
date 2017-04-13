using Assets.Scripts.Managers;
using Com.IsartDigital.BeTheBastard.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Com.IsartDigital.BeTheBastard.Scripts.Clickable
{

    /// <summary>
    /// 
    /// </summary>
    public class ClickableObject : MonoBehaviour
    {
        protected GameObject chaosBar;

        [SerializeField]
        protected float increaseValue;
        [SerializeField]
        protected float decreaseValue;

        protected void Start()
        {
            chaosBar = GameObject.FindGameObjectWithTag("chaos");

            increaseValue = Mathf.Min(increaseValue, 0.05f);
            increaseValue = Mathf.Min(increaseValue, 0.02f);

            decreaseValue = Mathf.Min(decreaseValue, 0.05f);
            decreaseValue = Mathf.Max(decreaseValue, 0.02f);
        }

        protected void Update()
        {

        }

        void OnMouseUp()
        {
            //chaosBar.GetComponent<UIBar>().Fill(increaseValue);
            ClickableManager.manager.SetObjectName(tag);
        }


    }
}