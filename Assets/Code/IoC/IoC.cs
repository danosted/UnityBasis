namespace Assets.Code.IoC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public class IoC
    {
        private ICollection<object> _container;
        public IoC()
        {
            _container = new HashSet<object>();
        }

        public T Resolve<T>() where T : new()
        {
            var entity = (T)_container.FirstOrDefault(e => e.GetType() == typeof(T));

            if (entity != null)
            {
                return entity;
            }

            entity = (T)Activator.CreateInstance(typeof(T), new object[] { });
            _container.Add(entity);

            return entity;
        }

        public T ResolvePrefab<T>() where T : UnityEngine.Object
        {
            var prefabs = Resources.LoadAll<T>("");
            var prefab = prefabs.FirstOrDefault<T>();
            if (prefab == null)
            {
                throw new UnityException(string.Format("Prefab resource not found. Type '{0}'.", typeof(T)));
            }
            var entity = UnityEngine.Object.Instantiate<T>(prefab);
            _container.Add(entity);
            return entity;
        }

        private T CreateInstance<T>() where T : new()
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { });
        }
    }
}
