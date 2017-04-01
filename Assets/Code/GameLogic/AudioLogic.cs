namespace Assets.Code.GameLogic
{
    using MonoBehaviours.Configuration;
    using Common;
    using DataAccess;
    using DataAccess.DTOs;
    using IoC;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class AudioLogic : LogicBase
    {

        public AudioLogic(IoC container, PrefabManager prefabManager, GlobalConfiguration config) : base(container, prefabManager, config)
        {
        }

        public void InitializeAudio()
        {
            var audioSystem = PrefabManager.GetPrefab(Configuration.audio_system);
            audioSystem.Activate(Container);
            audioSystem.SetupAudio(PrefabManager.GetPrefab(Configuration.audio_configuration_backgroun_01));
        }

    }
}
