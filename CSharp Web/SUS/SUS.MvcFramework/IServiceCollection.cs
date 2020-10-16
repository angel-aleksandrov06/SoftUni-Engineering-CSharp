namespace SUS.MvcFramework
{
    using System;

    public interface IServiceCollection
    {
        //.Add<IUsersService, UsersService>
        void Add<TSource, TDestination>();

        object CreateInstance(Type type);
    }
}
