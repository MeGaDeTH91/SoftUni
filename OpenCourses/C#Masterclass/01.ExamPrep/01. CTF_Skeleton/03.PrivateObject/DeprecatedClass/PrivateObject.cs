namespace DeprecatedClass
{
    using System.Reflection;

    public class PrivateObject
    {
        private object obj;
        public PrivateObject(object obj)
        {
            this.obj = obj;
        }

        public object Invoke(string methodName, params object[] parameters)
        {
            MethodInfo dynMethod = obj
                .GetType()
                .GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            return dynMethod.Invoke(obj, parameters);
        }
    }
}
