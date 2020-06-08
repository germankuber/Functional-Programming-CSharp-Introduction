using System;

namespace FunctionalIntro
{
    public static class FunctionExtensions
    {
        
        public static TResult Map<TSource, TResult>(
          this TSource @this,
          Func<TSource, TResult> fn) =>
            fn(@this);
        //TODO: 08 - 01 - Implemento Tee
        public static T Tee<T>(this T @this, Action<T> action)
        {
            action(@this);
            return @this;
        }
    }
}
