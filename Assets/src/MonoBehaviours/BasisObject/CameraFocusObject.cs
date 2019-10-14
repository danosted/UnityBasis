namespace Assets.Code.MonoBehaviours.Obstacles
{
    using UnityEngine;
    using IoC;
    using DataAccess;
    using GameLogic;
    using Common;
    using Utilities;

    public class CameraFocusObject : PrefabBase
    {
        protected float Speed { get; set; }
        protected ScreenUtil ScreenUtil => Container.Resolve<ScreenUtil>();
        public virtual void Activate(IoC container, Vector3 intialPosition)
        {
            base.Activate(container);
            Speed = 1f;
            transform.position = intialPosition;
            gameObject.SetActive(true);
        }

        protected virtual void Update()
        {
            ScreenUtil.SetFocusOnMe(this);
        }

        protected virtual void Move()
        {
            transform.Translate(Vector3.down * Time.deltaTime * Speed);
        }

        protected virtual void OnMouseEnter()
        {
            ScoreLogic.AddToScore(-(int)Speed);
            Deactivate();
        }
    }
}
