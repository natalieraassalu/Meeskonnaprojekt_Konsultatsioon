using System.Reflection;

namespace Abc.Aids;
    public static class GetType
    {
        public static IEnumerable<PropertyInfo> Properties<TClass>(BindingFlags f)
            =>typeof(TClass).GetProperties();
        public static IEnumerable<string> PropertyNames<TClass>(BindingFlags f) 
            =>Properties<TClass>(f).Select(p=>p.Name);
        public static IEnumerable<MethodInfo> Methods<TClass>(BindingFlags f, bool includeSpecialNames = false)
            => Array.FindAll(typeof(TClass).GetMethods(f), i => includeSpecialNames || !i.IsSpecialName);
        public static IEnumerable<string> MethodNames<TClass>(BindingFlags f, bool includeSpecialNames = false)
            => Methods<TClass>(f, includeSpecialNames).Select(p => p.Name);
}

