using Assets.Scripts.GameObjects.Player;
using Com.IsartDigital.BeTheBastard.Scripts.Managers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers
{

    /// <summary>
    /// 
    /// </summary>
    public class ClickableManager : BaseManager<ClickableManager>
    {
        public bool mate2HaveDrink = false;

        protected bool isClimTriggered;
        protected bool isDoorTriggered;
        protected bool isChairTriggered;
        protected bool isCoffeeTriggered;
        protected bool isDistribTriggered;

        public const string CLIM = "clim";
        public const string DOOR = "door";
        public const string CHAIR = "chair";
        public const string COFFEE = "coffee";
        public const string DISTRIB = "distrib";
        public const string LAPTOP = "laptot";
        protected const string NONE = "none";

        protected const string SABOT = "Saboter";
        protected const string UNPLUG = "débrancher";
        protected const string PAST_PANEL = "poser un panneau en panne";

        protected GameObject myPanel;
        protected GameObject pannelMail;
        protected Text rep1;

        protected string objectName;

        protected override void Awake()
        {
            base.Awake();
            SetObjectName();
        }

        protected void Start()
        {
            myPanel = GameObject.FindGameObjectWithTag("hudContextuel");
            pannelMail = GameObject.FindGameObjectWithTag("panelMail");
            rep1 = GameObject.FindGameObjectWithTag("contextuelReponse1").GetComponent<Text>();

            closePanel();
        }

        protected void Update()
        {

        }

        public bool isAClickable()
        {
            return objectName != NONE && !isAllwaysClicked(objectName);
        }

        public void SetObjectName(string pName = NONE)
        {
            objectName = pName;
            
        }

        public bool isAllwaysClicked(string pTag)
        {
            switch (pTag)
            {
                case CLIM:
                    return isClimTriggered;

                case DOOR:
                    return isDoorTriggered;
                case CHAIR:
                    return isChairTriggered;
                case COFFEE:
                    return isCoffeeTriggered;
                case DISTRIB:
                    return isDistribTriggered;
            }

            return false;
        }
        public void OpenPanel()
        {
            if (!isAClickable()) return;

            if(objectName == LAPTOP)
            {
                pannelMail.SetActive(true);
                return;
            }

            switch (objectName)
            {
                case CLIM:
                    rep1.text = SABOT;
                    break;
                case DOOR:
                    rep1.text = SABOT;
                    break;
                case CHAIR:
                    rep1.text = SABOT;
                    break;
                case COFFEE:
                    rep1.text = UNPLUG;
                    break;
                case DISTRIB:
                    rep1.text = PAST_PANEL;
                    break;
            }

            myPanel.SetActive(true);
        }

        public void OrderActionToPlayer()
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
                case COFFEE:
                    PlayerAgent.instance.SetModeCoffee();
                    break;
                case DISTRIB:
                    PlayerAgent.instance.SetModeDistrib();
                    break;
            }

            SetTrigger();
            SetObjectName();
        }

        public void closePanel()
        {
            pannelMail.SetActive(false);
            myPanel.SetActive(false);
            SetObjectName();
        }

        protected void SetTrigger()
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
                case COFFEE:
                    isCoffeeTriggered = true;
                    break;
                case DISTRIB:
                    isDistribTriggered = true;
                    break;
            }

            closePanel();
        }
    }
}