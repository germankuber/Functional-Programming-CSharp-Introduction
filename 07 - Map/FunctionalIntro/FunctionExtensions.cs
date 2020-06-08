using System;

namespace FunctionalIntro
{
    public static class FunctionExtensions
    {
        //TODO: 07 - 01 - Implemento Map
        public static TResult Map<TSource, TResult>(
          this TSource @this,
          Func<TSource, TResult> fn) =>
            fn(@this);
    }
}
