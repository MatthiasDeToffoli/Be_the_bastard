using Com.IsartDigital.BeTheBastard.Scripts.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Com.IsartDigital.BeTheBastard.Scripts.Managers.NonPhysicsManager
{
    /// <summary>
    /// author : Matthias de Toffoli
    /// detect if we use pad or keyboard and detect using of there
    /// </summary>
    public class KeyManager : BaseManager<KeyManager>
    {
        #region properties
        /// <summary>
        ///call for check if we use an input 
        /// </summary>
        public Action checkKey { get; protected set; }
        const string LT = "LT";
        const string RT = "RT";

        public bool isInFightMode { get; protected set; }
        /// <summary>
        ///dictionary of boolean said if we use LT or RT 
        /// </summary>
        protected Dictionary<string, bool> triggerDown;

        [SerializeField]
        private float triggerSensitivity;
        #endregion

        #region Events
        #region all
        public UnityEvent switchModeEvent { get; protected set; }
        public UnityEvent pauseEvent { get; protected set; }
        public FloatEvent moveVerEvent { get; protected set; }
        public FloatEvent moveHorEvent { get; protected set; }
        public FloatEvent camHorEvent { get; protected set; }
        public FloatEvent camVerEvent { get; protected set; }
        #endregion
        #region Fight

        public UnityEvent synchroEvent { get; protected set; }
        public UnityEvent lockEvent { get; protected set; }
        public UnityEvent protectionEvent { get; protected set; }
        public UnityEvent punchUpTodownEvent { get; protected set; }
        public UnityEvent punchLateralRightEvent { get; protected set; }
        public UnityEvent punchLateralLeftEvent { get; protected set; }
        public UnityEvent thrustEvent { get; protected set; }
        
        #endregion
        #region exploration
        public UnityEvent actionEvent { get; protected set; }
        public UnityEvent backEvent { get; protected set; }
        public UnityEvent jumpEvent { get; protected set; }
        #endregion
        #endregion

        #region Base function
        protected override void Awake()
        {
            base.Awake();
            isInFightMode = false;
            triggerDown = new Dictionary<string, bool>();
            triggerDown[LT] = false;
            triggerDown[RT] = false;

            triggerSensitivity = Mathf.Max(0, triggerSensitivity);
            triggerSensitivity = Mathf.Min(1, triggerSensitivity);

            initEvents();
        }

        protected void initEvents()
        {
            switchModeEvent = new UnityEvent();
            synchroEvent = new UnityEvent();
            lockEvent = new UnityEvent();
            protectionEvent = new UnityEvent();
            punchUpTodownEvent = new UnityEvent();
            punchLateralLeftEvent = new UnityEvent();
            punchLateralRightEvent = new UnityEvent();
            thrustEvent = new UnityEvent();
            pauseEvent = new UnityEvent();
            moveVerEvent = new FloatEvent();
            moveHorEvent = new FloatEvent();
            camVerEvent = new FloatEvent();
            camHorEvent = new FloatEvent();
            actionEvent = new UnityEvent();
            backEvent = new UnityEvent();
            jumpEvent = new UnityEvent();
        }

        protected void Start()
        {
            checkPad();
        }

        protected void Update()
        {

            checkPad();

            checkKey();
            
        }

        /// <summary>
        /// Said controller to use and if we are in fight mode or not
        /// </summary>
        protected void checkPad()
        {
            if (isInFightMode)
            {
                if (HaveAPad()) checkKey = CheckKeyPadFight;
                else checkKey = CheckKeyBoardFight;
            } else
            {
                if (HaveAPad()) checkKey = CheckKeyPadExploration;
                else checkKey = CheckKeyBoardExploration;
            }
            
        }


        #endregion

        #region Input functions

        /// <summary>
        /// Said if a gamepad is connected to the computer
        /// </summary>
        /// <returns> a gamepad is connected</returns>
        public bool HaveAPad()
        {
            if (Input.GetJoystickNames().Length <= 0) return false;
            else if (Input.GetJoystickNames()[0].Length <= 0) return false;
            else return true;
        }

        /// <summary>
        /// check keyboard's input for all mode
        /// </summary>
        /// <param name="pIsInFightMode">futur state of isInFightMode if we use the good button</param>
        protected void CheckKeyBoard(bool pIsInFightMode)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("up");
                camVerEvent.Invoke(1);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("down");
                camVerEvent.Invoke(-1);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("left");
                camHorEvent.Invoke(-1);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("right");
                camHorEvent.Invoke(1);
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("z");
                moveVerEvent.Invoke(1);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("S");
                moveVerEvent.Invoke(-1);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Q");
                moveHorEvent.Invoke(-1);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("D");
                moveHorEvent.Invoke(1);
            }

            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                Debug.Log("RightControl");
                switchModeEvent.Invoke();
                isInFightMode = pIsInFightMode;
            }
        }

        /// <summary>
        /// check pad's input for all mode
        /// </summary>
        /// <param name="pIsInFightMode">futur state of isInFightMode if we use the good button</param>
        protected void CheckKeyPad(bool pIsInFightMode)
        {
            if (Input.GetAxis(LT) > triggerSensitivity)
            {
                if (!triggerDown[LT])
                {
                    Debug.Log(LT);
                    onTriggerDown(LT);
                    switchModeEvent.Invoke();
                    isInFightMode = pIsInFightMode;
                }

            }
            else
            {
                onTriggerUp(LT);
            }

            if (Input.GetKeyDown(KeyCode.JoystickButton6)) Debug.Log("Select");
            if (Input.GetKeyDown(KeyCode.JoystickButton7))
            {
                Debug.Log("Start");
                pauseEvent.Invoke();
            }

            if (Input.GetAxis("LHorizontal") != 0)
            {
                Debug.Log("LJoy hor : " + Input.GetAxis("LHorizontal"));
                moveHorEvent.Invoke(Input.GetAxis("LHorizontal"));
            }
            if (Input.GetAxis("LVertical") != 0)
            {
                Debug.Log("LJoy ver : " + Input.GetAxis("LVertical"));
                moveVerEvent.Invoke(Input.GetAxis("LVertical"));
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton8)) Debug.Log("LJoy");

            if (Input.GetAxis("RHorizontal") != 0)
            {
                Debug.Log("RJoy hor : " + Input.GetAxis("RHorizontal"));
                camHorEvent.Invoke(Input.GetAxis("RHorizontal"));
            }
            if (Input.GetAxis("RVertical") != 0)
            {
                Debug.Log("RJoy ver : " + Input.GetAxis("RVertical"));
                camVerEvent.Invoke(Input.GetAxis("RVertical"));
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton9)) Debug.Log("RJoy");
        }

        /// <summary>
        /// check keybord's input in fight mode
        /// </summary>
        protected void CheckKeyBoardFight()
        {

            CheckKeyBoard(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space");
                thrustEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E");
                punchLateralRightEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("A");
                punchLateralLeftEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("F");
                punchUpTodownEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Debug.Log("LCONTROL");
                lockEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("LeftShift");
                protectionEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                Debug.Log("RightControl");
                synchroEvent.Invoke();
            }
        }

        /// <summary>
        /// check pad's input in fight mode
        /// </summary>
        protected void CheckKeyPadFight()
        {
            CheckKeyPad(false);

            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                Debug.Log("A");
                thrustEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                Debug.Log("B");
                punchLateralRightEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                Debug.Log("X");
                punchLateralLeftEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                Debug.Log("Y");
                punchUpTodownEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.JoystickButton4))
            {
                Debug.Log("LB");
                lockEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.JoystickButton5))
            {
                Debug.Log("RB");
                protectionEvent.Invoke();
            }

            if (Input.GetAxis(RT) > triggerSensitivity)
            {
                if(!triggerDown[RT])
                {
                    Debug.Log(RT);
                    onTriggerDown(RT);
                    synchroEvent.Invoke();
                }
                
            } else
            {
                onTriggerUp(RT);
            } 
        }

        /// <summary>
        /// check keybord's input in exploration mode
        /// </summary>
        protected void CheckKeyBoardExploration()
        {
            CheckKeyBoard(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space");
                jumpEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E");
                backEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("A");
                //punchLateralLeftEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("F");
                actionEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                Debug.Log("LCONTROL");
                //lockEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("LeftShift");
                //protectionEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                Debug.Log("RightControl");
                //synchroEvent.Invoke();
            }
        }

        /// <summary>
        /// check pad's input in exploration mode
        /// </summary>
        protected void CheckKeyPadExploration()
        {
            CheckKeyPad(true);

            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                Debug.Log("A");
                jumpEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                Debug.Log("B");
                backEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                Debug.Log("X");
                //punchLateralLeftEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                Debug.Log("Y");
                actionEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.JoystickButton4))
            {
                Debug.Log("LB");
                //lockEvent.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.JoystickButton5))
            {
                Debug.Log("RB");
                //protectionEvent.Invoke();
            }

            if (Input.GetAxis(RT) > triggerSensitivity)
            {
                if (!triggerDown[RT])
                {
                    Debug.Log(RT);
                    onTriggerDown(RT);
                    synchroEvent.Invoke();
                }

            }
            else
            {
                onTriggerUp(RT);
            }

           


        }

        /// <summary>
        /// pass a trigger to down
        /// <param name="triggerName">the name of the trigger to down</param>
        /// </summary>
        private void onTriggerDown(string triggerName)
        {
            triggerDown[triggerName] = true;
        }

        /// <summary>
        /// pass a trigger to up
        /// <param name="triggerName">the name of the trigger to up</param>
        /// </summary>
        private void onTriggerUp(string triggerName)
        {
            triggerDown[triggerName] = false;
        }
        #endregion
    }

}