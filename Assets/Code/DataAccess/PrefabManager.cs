namespace Assets.Code.DataAccess
{
    using IoC;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public class PrefabManager
    {
        private IoC _container;
        private ICollection<Object> _activePrefabs;
        private ICollection<Object> _inactivePrefabs;

        public PrefabManager(IoC container)
        {
            _container = container;
            _activePrefabs = new List<Object>();
            _inactivePrefabs = new List<Object>();
        }

        public T GetPrefab<T>() where T : Object
        {
            var prefab = (T)_inactivePrefabs.FirstOrDefault(p => p.GetType() == typeof(T));
            if(prefab != null)
            {
                _inactivePrefabs.Remove(prefab);
                _activePrefabs.Add(prefab);
                return prefab;
            }
            var resources = Resources.LoadAll<T>("");
            prefab = resources.FirstOrDefault();
            if (prefab == null)
            {
                throw new UnityException(string.Format("Prefab resource not found. Type '{0}'.", typeof(T)));
            }
            var entity = Object.Instantiate(prefab);
            _activePrefabs.Add(entity);
            return entity;
        }
    }
}
