namespace Assets.Code.DataAccess
{
    using IoC;
    using UnityEngine;

    public class PrefabManager
    {
        private IoC _container;

        public PrefabManager(IoC container)
        {
            _container = container;
        }

        public T GetPrefab<T>() where T : Object
        {
            return _container.ResolvePrefab<T>();
        }
    }
}
