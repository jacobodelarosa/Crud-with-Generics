namespace Travels.Application.Extensions
{
    public static class ObjectExtensions
    {
        public static TTarget Inject<TTarget>(this object source)
            where TTarget : new()
        {
            if (source == null)
                return default;

            var target = new TTarget();
            var sourceProperties = source.GetType().GetProperties();
            
            foreach (var sourceProperty in sourceProperties)
            {
                if (sourceProperty.CanRead && sourceProperty.GetGetMethod() != null)
                {
                    var targetProperty = target.GetType().GetProperty(sourceProperty.Name);
                    if (targetProperty != null 
                        && targetProperty.CanWrite 
                        && targetProperty.PropertyType == sourceProperty.PropertyType 
                        && targetProperty.GetSetMethod() != null)
                    {
                        targetProperty.SetValue(target, sourceProperty.GetValue(source, null), null);
                    }
                }
            }

            return target;
        }
    }
}
