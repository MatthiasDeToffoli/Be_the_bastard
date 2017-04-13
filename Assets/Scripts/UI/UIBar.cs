using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.IsartDigital.BeTheBastard.Scripts.UI
{

    public class UIBar : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Fill(float pValue)
        {
            Debug.Log(GetComponent<Scrollbar>().size);
            GetComponent<Scrollbar>().size += pValue;
        }

        public void UnFill(float pValue)
        {
            GetComponent<Scrollbar>().size -= pValue;
        }
    }
}
