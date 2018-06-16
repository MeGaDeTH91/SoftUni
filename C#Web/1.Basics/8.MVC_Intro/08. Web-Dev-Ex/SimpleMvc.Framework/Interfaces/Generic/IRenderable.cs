namespace SimpleMvc.Framework.Interfaces.Generic
{
    using System;

    public interface IRenderable<T> : IRenderable
    {
        T Model { get; set; }
    }
}
