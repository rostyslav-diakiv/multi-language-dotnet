﻿using Microsoft.FSharp.Collections;
using System.Collections.Generic;

namespace CSharpConsoleApp
{
    public static class Interop
    {
        public static FSharpList<T> ToFSharpList<T>(this IList<T> input)
        {
            return CreateFSharpList(input, 0);
        }

        private static FSharpList<T> CreateFSharpList<T>(IList<T> input, int index)
        {
            if (index >= input.Count)
            {
                return FSharpList<T>.Empty;
            }
            else
            {
                return FSharpList<T>.Cons(input[index], CreateFSharpList(input, index + 1));
            }
        }
    }
}
