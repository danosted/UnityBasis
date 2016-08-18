﻿namespace Assets.Code.Objects
{
    using UnityEngine;
    using IoC;
    using DataAccess;

    public class Initializer : MonoBehaviour
    {
        /// <summary>
        /// Master awake - no other awake methods should be used
        /// </summary>
        void Awake()
        {
            var ioc = new IoC();
            var pman = ioc.Resolve<PrefabManager>();
            var poc = pman.GetPrefab<PoC>();
        }
    }
}
