using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_OrderMakingApp.Utilities
{
    public class Container
    {
        private readonly Dictionary<Type, Type> types = new Dictionary<Type, Type>();
        public void Register<TInterface, TImplementation>() where TImplementation:TInterface
        {
            types[typeof(TInterface)] = typeof(TImplementation);
        }

        public TInterface Create<TInterface>()
        {
            return (TInterface)Create(typeof(TInterface));
        }

        private object Create(Type type)
        {
            var availableTypes = types[type];
            System.Reflection.ConstructorInfo defConstructor = availableTypes.GetConstructors()[0];
            System.Reflection.ParameterInfo[] defParams = defConstructor.GetParameters();

            var parameters = defParams.Select(param => Create(param.ParameterType)).ToArray();

            return defConstructor.Invoke(parameters);
        }

    }
}
