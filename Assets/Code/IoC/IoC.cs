namespace Assets.Code.IoC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IoC
    {
        private ICollection<object> _container;
        public IoC()
        {
            _container = new HashSet<object>();
        }

        public T Resolve<T>()
        {
            var entity = (T)_container.FirstOrDefault(e => e.GetType() == typeof(T));

            if (entity != null)
            {
                return entity;
            }

            entity = (T)Activator.CreateInstance(typeof(T), new object[] { this });
            _container.Add(entity);

            return entity;
        }

        private T CreateInstance<T>() where T : new()
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { });
        }
    }
}
