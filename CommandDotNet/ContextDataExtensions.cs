using System;

namespace CommandDotNet
{
    public static class ContextDataExtensions
    {
        public static T GetOrAdd<T>(this IServices services, Func<T> create) where T: class
        {
            var service = services.GetOrDefault<T>();

            if (service == null)
            {
                service = create();
                if (service == null)
                {
                    throw new AppRunnerException($"'{create}' returned null");
                }
                services.Add(service);
            }

            return service;
        }
    }
}