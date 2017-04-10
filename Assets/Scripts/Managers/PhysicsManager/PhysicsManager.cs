using System.Collections.Generic;
using UnityEngine;

namespace Com.IsartDigital.BeTheBastard.Scripts.Managers.PhysicsManager
{

    /// <summary>
    /// author : Matthias de Toffoli
    /// Mother class of managers which manage physics object
    /// </summary>
    public class PhysicsManager<T0,T1> : BaseManager<T0> where T0 : Component
    {
        #region propriétés
        /// <summary>
        ///list of object use by manager 
        /// </summary>
        protected List<T1> objectsList;

        public bool listIsEmpty { get { return objectsList.Count == 0; } }
        #endregion

        #region Base function
        virtual protected void Start()
        {


        }

        override protected void Awake()
        {
            objectsList = new List<T1>();
            base.Awake();
        }

        /// <summary>
        /// add an object to the list
        /// </summary>
        /// <param name="value">the object to add</param>
        virtual public void AddToList(T1 value)
        {
            objectsList.Add(value);
        }

        /// <summary>
        /// remove an object to the list
        /// </summary>
        /// <param name="value">object to remove</param>
        public void RemoveToList(T1 value)
        {
            objectsList.Remove(value);
        }

        virtual protected void OnDestroy()
        {

        }


        #endregion

        #region listener functions
        
        #endregion

    }
}