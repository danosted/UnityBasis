namespace Assets.Code.MonoBehaviours.Obstacles
{
    using UnityEngine;
    using IoC;
    using DataAccess;
    using GameLogic;
    using Common;
    using Utilities;

    public class MoveableObject : PrefabBase
    {
        protected float Speed { get; set; }

        public virtual void Activate(IoC container, Vector3? intialPosition = null)
        {
            base.Activate(container);
            Speed = Speed == 0f ? 1f : Speed;
            transform.position = intialPosition ?? Vector3.zero;
            gameObject.SetActive(true);
        }

        protected virtual void Update()
        {
            Move();
            CheckOutOfBounds();
        }

        protected virtual void Move()
        {
            transform.Translate(Vector3.down * Time.deltaTime * Speed);
        }

        protected virtual void CheckOutOfBounds()
        {
            if(!Container.Resolve<ScreenUtil>().IsOutOfViewportBounds(transform.position))
            {
                return;
            }
            Deactivate();
        }

        protected virtual void OnMouseEnter()
        {
            ScoreLogic.AddToScore(-(int)Speed);
            Deactivate();
        }
    }
}
