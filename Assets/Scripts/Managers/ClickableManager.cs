using Assets.Scripts.GameObjects.Player;
using UnityEngine;

namespace Assets.Scripts.Managers
{

    /// <summary>
    /// 
    /// </summary>
    public class ClickableManager : MonoBehaviour
    {

        protected bool isClimTriggered;
        protected bool isDoorTriggered;
        protected bool isChairTriggered;

        protected const string CLIM = "clim";
        protected const string DOOR = "door";
        protected const string CHAIR = "chair";

        protected string objectName;


        protected void Start()
        {

        }

        protected void Update()
        {

        }

        protected void SetObjectName(string pName)
        {
            objectName = pName;
        }

        protected void OrderActionToPlayer()
        {
            switch (objectName){
                case CLIM:
                    PlayerAgent.instance.SetModeClim();
                    break;
                case DOOR:
                    PlayerAgent.instance.SetModeDoor();
                    break;
                case CHAIR:
                    PlayerAgent.instance.SetModeChair();
                    break;
            }
        }

        public void SetTrigger()
        {
            switch (objectName)
            {
                case CLIM:
                    isClimTriggered = true;
                    break;
                case DOOR:
                    isDoorTriggered = true;
                    break;
                case CHAIR:
                    isChairTriggered = true;
                    break;
            }
        }
    }
}