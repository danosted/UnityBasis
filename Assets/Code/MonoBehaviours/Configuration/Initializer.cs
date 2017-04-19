namespace Assets.Code.MonoBehaviours.Configuration
{
    using UnityEngine;
    using IoC;
    using GameLogic;
    using DataAccess;

    public class Initializer : MonoBehaviour
    {
        [Header("Global Configuration Prefab"), Tooltip("Find under Assets/Prefabs/Configuration/")]
        public GlobalConfiguration GlobalConfiguration;
        private IoC Container { get; set; }
        private PrefabManager PrefabManager { get; set; }

        /// <summary>
        /// Master awake - no other awake methods should be used
        /// </summary>
        void Awake()
        {
            // Initialize "IoC" container with the configuration to distribute
            Container = new IoC(GlobalConfiguration);
            PrefabManager = Container.Resolve<PrefabManager>();
            
            // Initialize game...
            InitializeGame();

        }

        private void InitializeGame()
        {
            // Initialize Game
            var control = Container.Resolve<FlowLogic>();
            control.StartGameFlow();
        }

        // TODO 1 (DRO): Move to a more fitting location
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Container.Resolve<FlowLogic>().GameOver();
            }
            if (!PrefabManager.GetConfiguration().param_game_over) return;
            if (Input.GetMouseButtonDown(0))
            {
                Container.Resolve<FlowLogic>().RestartGame();
            }
        }
    }
}
