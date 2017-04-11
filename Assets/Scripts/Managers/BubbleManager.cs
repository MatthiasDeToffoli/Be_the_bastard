using UnityEngine;

namespace Com.IsartDigital.BeTheBastard.Scripts.Managers
{

    /// <summary>
    /// 
    /// </summary>
    public class BubbleManager : MonoBehaviour
    {
        [SerializeField]
        protected GameObject myBubble;

        protected GameObject myButton;

        protected void Start()
        {
            myButton = GameObject.FindGameObjectWithTag("testButton");
        }

        protected void Update()
        {

        }

    }
}