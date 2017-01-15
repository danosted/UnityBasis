namespace Assets.Code.GameLogic
{
    using MonoBehaviours.Configuration;
    using Common;
    using DataAccess;
    using IoC;
    using Common.DataObjects;

    public class ScoreLogic : LogicBase
    {
        #region Properties
        private ScoreObject _score;
        #endregion

        #region Constructors
        public ScoreLogic(IoC container, PrefabManager prefabManager, GlobalConfiguration config) : base(container, prefabManager, config)
        {
            _score = new ScoreObject
            {
                CurrentScore = 0,
            };
        }
        #endregion
        
        public void ModifyScore(int toAdd)
        {
            _score.CurrentScore += toAdd;
        }
    }
}