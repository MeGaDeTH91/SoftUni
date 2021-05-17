namespace MasterInjection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MyServiceProvider : IMyServiceProvider
    {
        private readonly Dictionary<Type, Type> types;
        public MyServiceProvider()
        {
            this.types = new Dictionary<Type, Type>();
        }

        public void Add<TSource, TDestination>()
            where TDestination : TSource
        {
            types[typeof(TSource)] = typeof(TDestination);
        }

        public object CreateInstance(Type type)
        {
            if (!types.ContainsKey(type) && !types.ContainsValue(type))
            {
                return null;
            }
            return CreateNewInstanceWithParams(GetCorrectRegisteredType(type));
        }

        public T CreateInstance<T>()
        {
            var currType = typeof(T);
            if (!types.ContainsKey(currType) && !types.ContainsValue(currType))
            {
                return default(T);
            }
            
            return (T)CreateInstance(typeof(T));
        }

        private object CreateNewInstanceWithParams(Type instanceType)
        {
            var constructor = instanceType
                            .GetConstructors()
                            .OrderBy(x => x.GetParameters().Length)
                            .FirstOrDefault();
            
            var constructorParams = constructor.GetParameters();

            var parameters = constructorParams.Select(param => CreateNewInstanceWithParams(GetCorrectRegisteredType(param.ParameterType))).ToArray();

            return constructor.Invoke(parameters);
        }

        private Type GetCorrectRegisteredType(Type type)
        {
            return types.ContainsKey(type) ? types[type] : types.Values.FirstOrDefault(x => x.Name == type.Name);
        }
    }
}
