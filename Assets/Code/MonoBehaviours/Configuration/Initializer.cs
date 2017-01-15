﻿namespace Assets.Code.MonoBehaviours.Configuration
{
    using UnityEngine;
    using IoC;
    using GameLogic;

    public class Initializer : MonoBehaviour
    {
        public GlobalConfiguration Config;

        /// <summary>
        /// Master awake - no other awake methods should be used
        /// </summary>
        void Awake()
        {
            // Initialize IoC container
            var ioc = new IoC(Config);

            // TODO Initialize game...
            var poclogic = ioc.Resolve<PoCLogic>();
            poclogic.StartPOC();
        }
    }
}
