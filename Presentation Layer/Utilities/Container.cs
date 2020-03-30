using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation_Layer.Utilities
{
    public class Container
    {
        private readonly Dictionary<Type, Type> types = new Dictionary<Type, Type>();
        private readonly Dictionary<Type, object> implementations = new Dictionary<Type, object>();
        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            types[typeof(TInterface)] = typeof(TImplementation);
        }

        public void RegisterImplementation<Type>(object implementation)
        {
            if (implementation.GetType() == typeof(Type) || implementation.GetType().GetInterfaces().Contains(typeof(Type)))
                implementations[typeof(Type)] = implementation;
        }

        public TInterface Create<TInterface>()
        {
            return (TInterface)Create(typeof(TInterface));
        }

        private object Create(Type type)
        {
            if (implementations.ContainsKey(type))
                return implementations[type];

            var availableTypes = types[type];

            System.Reflection.ConstructorInfo defConstructor = availableTypes.GetConstructors()[0];
            System.Reflection.ParameterInfo[] defParams = defConstructor.GetParameters();

            var parameters = defParams.Select(param => {
                if (implementations.ContainsKey(param.GetType()))
                    return implementations[param.GetType()];
                else
                    return Create(param.ParameterType);
                                                        }).ToArray();

            return defConstructor.Invoke(parameters);
        }

    }
}
