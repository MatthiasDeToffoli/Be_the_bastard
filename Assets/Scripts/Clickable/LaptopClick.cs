using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Clickable
{

    /// <summary>
    /// 
    /// </summary>
    public class LaptopClick : MonoBehaviour
    {

        protected void Start()
        {

        }

        protected void Update()
        {

        }

        protected void OnMouseUp()
        {
            ClickableManager.manager.SetObjectName(tag);
        }
    }
}