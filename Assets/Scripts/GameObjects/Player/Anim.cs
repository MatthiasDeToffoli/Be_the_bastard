using UnityEngine;

namespace Assets.Scripts.GameObjects.Player
{

    /// <summary>
    /// 
    /// </summary>
    public class Anim : MonoBehaviour
    {

        protected void Start()
        {
            GetComponent<Animation>().wrapMode = WrapMode.Loop;
//GetComponent<Animation>().Play("bobble");
            //GetComponent<Animation>().Play("drink");

            //GetComponent<Animation>().Play("fight");
            //GetComponent<Animation>().Play("sleep");
           GetComponent<Animation>().Play("use_computer");
            //GetComponent<Animation>().Play("walk");

        }

        protected void Update()
        {

        }
    }
}