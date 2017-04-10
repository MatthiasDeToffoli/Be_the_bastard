namespace Com.IsartDigital.BeTheBastard.Scripts.Managers
{
    using UnityEngine;
    using System.Collections;
    using UnityEngine.Events;

	public abstract class BaseManager<T> : SingletonManager<T> where T : Component
	{
		[HideInInspector]
		public bool isReady { get; protected set; }

		protected override void Awake()
		{
			base.Awake();
			isReady = false;

		}

	}
}
