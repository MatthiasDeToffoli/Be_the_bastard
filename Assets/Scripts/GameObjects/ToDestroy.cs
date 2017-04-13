using UnityEngine;

namespace Assets.Scripts.GameObjects
{

    /// <summary>
    /// 
    /// </summary>
    public class ToDestroy : MonoBehaviour
    {

        protected Animation anim;

        protected void Start()
        {
            anim = GetComponent<Animation>();
        }

        protected void Update()
        {

        }

        public void fall()
        {
            //anim.Play();
            Debug.Log("chut");
        }

        
    }
}