namespace Assets.Code.IoC
{
    using DataAccess;
    using MonoBehaviours.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public class IoC
    {
        private ICollection<object> _container { get; set; }
        private PrefabManager PrefabManager { get; set; }
        private GlobalConfiguration Configuration { get; set; }

        public IoC(GlobalConfiguration config)
        {
            // Initialize Container
            _container = new HashSet<object>();

            // Initialize PrefabManager
            PrefabManager = Resolve<PrefabManager>();

            // Initialize GlobalConfiguration
            Configuration = PrefabManager.GetPrefab(config);
        }

        public T Resolve<T>()
        {
            var entity = (T)_container.FirstOrDefault(e => e.GetType() == typeof(T));

            if (entity != null)
            {
                return entity;
            }

            try
            {
                if (typeof(T).GetConstructor(new[] { typeof(IoC) }) != null)
                {
                    entity = (T)Activator.CreateInstance(typeof(T), new object[] { this });
                }
                else if (typeof(T).GetConstructor(new[] { typeof(IoC), PrefabManager.GetType(), Configuration.GetType() }) != null)
                {
                    entity = (T)Activator.CreateInstance(typeof(T), new object[] { this, PrefabManager, Configuration });
                }
                else
                {
                    entity = (T)Activator.CreateInstance(typeof(T), new object[] { });
                }
            }
            catch(Exception e)
            {
                var errorMsg = string.Format("IOC Error when resolving type. Type {0}. Message {1}.", typeof(T), e.Message);
                throw new UnityException(errorMsg, e);
            }
            _container.Add(entity);

            return entity;
        }

        private T CreateInstance<T>() where T : new()
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { });
        }
    }
}
