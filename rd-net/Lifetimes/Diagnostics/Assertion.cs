using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using JetBrains.Annotations;
using JetBrains.Threading;
using JetBrains.Util;
using System.Diagnostics.CodeAnalysis;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;

namespace JetBrains.Diagnostics
{
  [System.ComponentModel.Localizable(false)]
  public static class Assertion
  {
    [ContractAnnotation("condition:false=>void")]
    [AssertionMethod]
    [Conditional("JET_MODE_ASSERT")]
    public static void Assert([DoesNotReturnIf(false)] bool condition, string message)
    {
      if (!condition)
      {
        Fail(message);
      }
    }

    [AssertionMethod]
    [Conditional("JET_MODE_ASSERT")]
    public static void AssertCurrentThread(Thread thread)
    {
      if (Thread.CurrentThread != thread)
      {
        Fail("Current thread <{0}> is not equal to referent thread <{1}>", Thread.CurrentThread.ToThreadString(), thread.ToThreadString());
      }
    }

    [ContractAnnotation("condition:false=>void")]
    [AssertionMethod, StringFormatMethod("message")]
    [Conditional("JET_MODE_ASSERT")]
    public static void Assert<T>([DoesNotReturnIf(false)] bool condition, string message, T? arg)
    {
      if (!condition)
      {
        Fail(message, arg);
      }
    }
    
    [ContractAnnotation("condition:false=>void")]
    [AssertionMethod, StringFormatMethod("message")]
    [Conditional("JET_MODE_ASSERT")]
    public static void Assert<T1,T2>([DoesNotReturnIf(false)] bool condition, string message, T1? arg1, T2? arg2)
    {
      if (!condition)
      {
        Fail(message, arg1, arg2);
      }
    }

    [ContractAnnotation("condition:false=>void")]
    [AssertionMethod, StringFormatMethod("message")]
    [Conditional("JET_MODE_ASSERT")]
    public static void Assert<T1, T2, T3>([DoesNotReturnIf(false)] bool condition, string message, T1? arg1, T2? arg2, T3? arg3)
    {
      if (!condition)
      {
        Fail(message, arg1, arg2, arg3);
      }
    }

    [ContractAnnotation("condition:false=>void")]
    [AssertionMethod, StringFormatMethod("message")]
    [Conditional("JET_MODE_ASSERT")]
    public static void Assert<T1, T2, T3, T4>([DoesNotReturnIf(false)] bool condition, string message, T1? arg1, T2? arg2, T3? arg3, T4? arg4)
    {
      if (!condition)
      {
        Fail(message, arg1, arg2, arg3, arg4);
      }
    }

    [ContractAnnotation("condition:false=>void")]
    [AssertionMethod, StringFormatMethod("message")]
    [Conditional("JET_MODE_ASSERT")]
    public static void Assert([DoesNotReturnIf(false)] bool condition, string message, params object?[] args)
    {
      if (!condition)
      {
        Fail(message, args);
      }
    }

    [ContractAnnotation("=>void")]
    [AssertionMethod]
    [DoesNotReturn]
    public static void Fail(string message)
    {
      throw new AssertionException(message);
    }

    [ContractAnnotation("=>void")]
    [AssertionMethod, StringFormatMethod("message")]
    [DoesNotReturn]
    public static void Fail(string message, object? arg)
    {
      Fail(string.Format(message, arg));
    }

    [ContractAnnotation("=>void")]
    [AssertionMethod, StringFormatMethod("message")]
    [DoesNotReturn]
    public static void Fail(string message, object? arg1, object? arg2)
    {
      Fail(string.Format(message, arg1, arg2));
    }

    [ContractAnnotation("=>void")]
    [AssertionMethod, StringFormatMethod("message")]
    [DoesNotReturn]
    public static void Fail(string message, object? arg1, object? arg2, object? arg3)
    {
      Fail(string.Format(message, arg1, arg2, arg3));
    }

    [ContractAnnotation("=>void")]
    [AssertionMethod, StringFormatMethod("message")]
    [DoesNotReturn]
    public static void Fail(string message, params object?[] args)
    {
      Fail(args == null || args.Length == 0 ? message : String.Format(message, args));
    }

    [ContractAnnotation("condition:null=>void")]
    [AssertionMethod]
    [Conditional("JET_MODE_ASSERT")]
    public static void AssertNotNull([CodeAnalysis.NotNull] object? condition, string message)
    {
      if (condition == null)
      {
        Fail(message);
      }
    }


    [ContractAnnotation("condition:null=>void")]
    [AssertionMethod, StringFormatMethod("message")]
    [Conditional("JET_MODE_ASSERT")]
    public static void AssertNotNull([CodeAnalysis.NotNull] object? condition, string message, object? arg)
    {
      if (condition == null)
      {
        Fail(message, arg);
      }
    }

    [ContractAnnotation("condition:null=>void")]
    [AssertionMethod, StringFormatMethod("message")]
    [Conditional("JET_MODE_ASSERT")]
    public static void AssertNotNull([CodeAnalysis.NotNull] object? condition, string message, object? arg1, object? arg2)
    {
      if (condition == null)
      {
        Fail(message, arg1, arg2);
      }
    }

    [ContractAnnotation("condition:null=>void")]
    [AssertionMethod, StringFormatMethod("message")]
    [Conditional("JET_MODE_ASSERT")]
    public static void AssertNotNull([CodeAnalysis.NotNull] object? condition, string message, object? arg1, object? arg2, object? arg3)
    {
      if (condition == null)
      {
        Fail(message, arg1, arg2, arg3);
      }
    }

    [ContractAnnotation("condition:null=>void")]
    [AssertionMethod, StringFormatMethod("message")]
    [Conditional("JET_MODE_ASSERT")]
    public static void AssertNotNull([CodeAnalysis.NotNull] object? condition, string message, params object?[] args)
    {
      if (condition == null)
      {
        Fail(message, args);
      }
    }

    [ContractAnnotation("value:null => void; => value:notnull, notnull")]
    [MethodImpl(MethodImplAdvancedOptions.AggressiveInlining)]
    public static T NotNull<T>(this T? value, object debugMessage) where T : class
    {
      if (value == null)
      {
        Fail("NRE, debug message: "+ debugMessage);
      }

      return value;
    }

    [ContractAnnotation("value:null => void; => value:notnull, notnull")]
    [MethodImpl(MethodImplAdvancedOptions.AggressiveInlining)]
    public static T NotNull<T>(this T? value, string message) where T : class
    {
      if (value == null)
      {
        Fail(message);
      }

      return value;
    }

    [ContractAnnotation("value:null => void; => value:notnull, notnull")]
    [StringFormatMethod("args")]
    [MethodImpl(MethodImplAdvancedOptions.AggressiveInlining)]
    public static T NotNull<T>(this T? value, string message, params object?[] args) where T : class
    {
      if (value == null)
      {
        Fail(message, args);
      }

      return value;
    }

    [ContractAnnotation("value:null => void; => value:notnull, notnull")]
    [MethodImpl(MethodImplAdvancedOptions.AggressiveInlining)]
    public static T NotNull<T>(this T? value) where T : class
    {
      if (value == null)
      {
        Fail("{0} is null", typeof(T).FullName);
      }

      return value;
    }

    [ContractAnnotation("value:null => void; => value:notnull")]
    [MethodImpl(MethodImplAdvancedOptions.AggressiveInlining)]
    public static T NotNull<T>(this T? value, string message) where T : struct
    {
      if (value == null)
      {
        Fail(message);
      }

      return value.GetValueOrDefault();
    }

    [ContractAnnotation("value:null => void; => value:notnull")]
    [MethodImpl(MethodImplAdvancedOptions.AggressiveInlining)]
    public static T NotNull<T>(this T? value) where T : struct
    {
      if (value == null)
      {
        Fail("{0}? is null", typeof(T).FullName);
      }

      return value.GetValueOrDefault();
    }

    [MethodImpl(MethodImplAdvancedOptions.AggressiveInlining), StringFormatMethod("message"), AssertionMethod]
    public static void Require([DoesNotReturnIf(false)] bool value, string message)
    {
      if (!value)
      {
        Fail(message);
      }
    }

    [MethodImpl(MethodImplAdvancedOptions.AggressiveInlining), StringFormatMethod("message"), AssertionMethod]
    public static void Require([DoesNotReturnIf(false)] bool value, string message, object? arg1)
    {
      if (!value)
      {
        Fail(message, arg1);
      }
    }

    [MethodImpl(MethodImplAdvancedOptions.AggressiveInlining), StringFormatMethod("message"), AssertionMethod]
    public static void Require([DoesNotReturnIf(false)] bool value, string message, object? arg1, object? arg2)
    {
      if (!value)
      {
        Fail(message, arg1, arg2);
      }
    }

    [MethodImpl(MethodImplAdvancedOptions.AggressiveInlining), StringFormatMethod("message"), AssertionMethod]
    public static void Require([DoesNotReturnIf(false)] bool value, string message, params object?[] args)
    {
      if (!value)
      {
        Fail(message, args);
      }
    }

    [Serializable]
    public class AssertionException : Exception
    {
      public AssertionException(string message) : base(message) { }
      
      protected AssertionException(SerializationInfo info, StreamingContext context) : base(info, context)
      {
      }
    }
  }
}