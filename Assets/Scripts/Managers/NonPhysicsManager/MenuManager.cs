using UnityEngine;
using UnityEngine.Events;

namespace Com.IsartDigital.BeTheBastard.Scripts.Managers.NonPhysicsManager
{

    /// <summary>
    /// author : Matthias de Toffoli
    /// Manage differents menu and boutons
    /// </summary>
    
    public class MenuManager : BaseManager<MenuManager>
    {
        #region panel
        
        #endregion

        #region event
        public UnityEvent setMenu { get; protected set; }
        public UnityEvent setResume { get; protected set; }
        #endregion

        #region button Interraction
        public void Play()
        {
            
        }

        public void Return()
        {
           
        }

        public void Resume()
        {
            setResume.Invoke();
        }

        public void Menu()
        {
            setMenu.Invoke();
        }

        #endregion

        #region Base function
        protected void Start()
        {
        }

        protected void OnDestroy()
        {
        }
        protected override void Awake()
        {
            setResume = new UnityEvent();
            setMenu = new UnityEvent();

            

            base.Awake();
            
        }


        public void Lunch()
        {
            GameManager.manager.setInGame();

            
        }

        
        #endregion


    }
}