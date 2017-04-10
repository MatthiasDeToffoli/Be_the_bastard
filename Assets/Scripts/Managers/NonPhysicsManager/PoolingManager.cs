using UnityEngine;
using System.Collections.Generic;

namespace Com.IsartDigital.BeTheBastard.Scripts.Managers.NonPhysicsManager
{

    /// <summary>
    /// manage of pooling
    /// </summary>

    public class PoolingManager : BaseManager<PoolingManager>
    {
        #region properties
        /// <summary>
        ///Dictionary of pool 
        /// </summary>
        protected Dictionary<string, List<GameObject>> poolArray;

        /// <summary>
        ///list of object use by pooling 
        /// </summary>
        [SerializeField]
        List<GameObject> objectList;
        /// <summary>
        ///list of object created at start 
        /// </summary>
        [SerializeField]
        List<int> maxList;
        #endregion

        #region base functions
        protected override void Awake()
        {
            base.Awake();
            poolArray = new Dictionary<string, List<GameObject>>();
        }

        protected void Start()
        {
            CreatePool();
        }

        #endregion

        #region pool functions
        /// <summary>
        ///create the pool and object at start 
        /// </summary>
        protected void CreatePool()
        {
            for(int i = 0; i < objectList.Count; i++)
            {
                for(int j = 0; j < maxList[i]; j++)
                {
                    if (!poolArray.ContainsKey(objectList[i].name)) poolArray[objectList[i].name] = new List<GameObject>();
                    GameObject myObject = Instantiate(objectList[i]);
                    poolArray[objectList[i].name].Add(myObject);
                    myObject.SetActive(false);
                }
            }
        }

        /// <summary>
        ///give a pool object 
        /// </summary>
        /// <param name="pObject">the type of object to get</param>
        /// <returns>the object want</returns>
        public GameObject GetFromPool(GameObject pObject)
        {
            List<GameObject> pList = poolArray[pObject.name];
            GameObject myObject;

            if (pList.Count == 0)
            {
                myObject = Instantiate(pObject);
            }
            else
            {
                myObject = pList[0];
                pList.Remove(myObject);
                poolArray[pObject.name] = pList;
            }

            myObject.SetActive(true);
            return myObject;
        }


        /// <summary>
        ///add an object to the pool 
        /// </summary>
        /// <param name="pObject">the object to add</param>
        public void AddToPool(GameObject pObject)
        {
            string pName = pObject.gameObject.name.Replace("(Clone)", "");

            poolArray[pName].Add(pObject);
            
            pObject.SetActive(false);

        }

        #endregion
    }
}