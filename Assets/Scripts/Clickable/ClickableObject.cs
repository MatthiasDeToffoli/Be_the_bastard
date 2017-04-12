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

        public GameObject myPanel;
        public Text rep1;
        public Text rep2;

        protected void Start()
        {
            chaosBar = GameObject.FindGameObjectWithTag("chaos");

            increaseValue = Mathf.Min(increaseValue, 0.05f);
            increaseValue = Mathf.Min(increaseValue, 0.02f);

            decreaseValue = Mathf.Min(decreaseValue, 0.05f);
            decreaseValue = Mathf.Max(decreaseValue, 0.02f);

            myPanel = GameObject.FindGameObjectWithTag("hudContextuel");
            rep1 = GameObject.FindGameObjectWithTag("contextuelReponse1").GetComponent<Text>();
            rep2 = GameObject.FindGameObjectWithTag("contextuelReponse2").GetComponent<Text>();

            myPanel.SetActive(false);
        }

        protected void Update()
        {

        }

        void OnMouseDown()
        {
            
            rep1.text = "Réponse 1";
            rep2.text = "Réponse 2";
            //chaosBar.GetComponent<UIBar>().Fill(increaseValue);
            myPanel.SetActive(true);
        }
    }
}