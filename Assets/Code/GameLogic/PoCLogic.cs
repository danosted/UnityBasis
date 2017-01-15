namespace Assets.Code.GameLogic
{
    using MonoBehaviours.Configuration;
    using Common;
    using DataAccess;
    using IoC;

    public class PoCLogic : LogicBase
    {
        #region Constructors
        public PoCLogic(IoC container, PrefabManager prefabManager, GlobalConfiguration config) : base(container, prefabManager, config)
        {
        }
        #endregion

        public void StartPOC()
        {
            var poc = PrefabManager.GetPrefab(Configuration.prefab_PoC);
        }
    }
}