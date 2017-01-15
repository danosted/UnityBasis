namespace Assets.Code.GameLogic
{
    using MonoBehaviours.Configuration;
    using Common;
    using DataAccess;
    using IoC;

    public class ScoreLogic : LogicBase
    {
        #region Constructors
        public ScoreLogic(IoC container) : base(container)
        {
        }

        public ScoreLogic(IoC container, PrefabManager prefabManager, GlobalConfiguration config) : base(container, prefabManager, config)
        {
        }
        #endregion

        public void StartPOC()
        {
            
        }
    }
}