using UnityEngine.Events;

namespace Com.IsartDigital.BeTheBastard.Scripts.Managers.NonPhysicsManager
{

    /// <summary>
    /// author : Matthias de Toffoli
    /// Manage the different state of the game
    /// </summary>

    public class GameManager : BaseManager<GameManager>
    {

        #region event

        #endregion

        #region enum var
        /// <summary>
        /// state the game can take
        /// </summary>
        protected enum GameState { InGame,GameWin, GameOver,Menu}
        /// <summary>
        /// the current state of the game
        /// </summary>
        protected GameState state;
        /// <summary>
        /// state saved at start of pause
        /// </summary>
        protected GameState stateInPause;
        #endregion

        #region boolean var
        /// <summary>
        /// said if the state is InGame
        /// </summary>
        public bool isInGame { get { return state == GameState.InGame; } }
        /// <summary>
        /// said if the state before pose is InGame
        /// </summary>
        public bool beforePauseIsInGame { get { return stateInPause == GameState.InGame; } }
        /// <summary>
        /// said if the state is GameWin
        /// </summary>
        public bool isWin { get { return state == GameState.GameWin; } }
        /// <summary>
        /// said if the state is Loos
        /// </summary>
        public bool isLoos { get { return state == GameState.GameOver; } }
        /// <summary>
        /// said if the state is Pause
        /// </summary>
        public bool isPause { get { return state == GameState.Menu; } }
        #endregion

        #region setter
        /// <summary>
        /// game take the state InGame
        /// </summary>
        public void setInGame()
        {
            state = GameState.InGame;
        }

        /// <summary>
        /// game take the state Menu
        /// </summary>
        public void setMenu()
        {
            stateInPause = state;
            state = GameState.Menu;
        }

        /// <summary>
        /// game take the state Win
        /// </summary>
        public void setWin()
        {
            state = GameState.GameWin;
        }

        /// <summary>
        /// game take the state Loos
        /// </summary>
        public void setLoos()
        {
            state = GameState.GameOver;
        }

        /// <summary>
        /// game take the state before pause
        /// </summary>
        public void setResum()
        {
            state = stateInPause;
        }

        #endregion
     

        #region Base function

        protected void Start()
        {
            if (MenuManager.manager)
            {
                MenuManager.manager.setResume.AddListener(setResum);
            }
        }

        protected void OnDestroy()
        {
            if (MenuManager.manager)
            {
                MenuManager.manager.setResume.RemoveListener(setResum);
            }
        }

        protected override void Awake()
        {
            base.Awake();
            state = GameState.Menu;
        }

        #endregion

        #region listener
        
        #endregion


    }
}