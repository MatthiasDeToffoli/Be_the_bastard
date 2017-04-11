using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Com.IsartDigital.BeTheBastard.Scripts.UI
{

    public class BubbleButton : MonoBehaviour
    {
        [SerializeField]
        protected GameObject myBubble;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnMouseDown()
        {
            Debug.Log("click boutton");
            Instantiate(myBubble);
        }
    }
}
