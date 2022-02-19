using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace Lab1_4_String_Exception
{
	public static class ExceptionHandler
	{
		static ExceptionHandler()
		{
			exceptions = new();
			dispatchInfos = new();
		}

		private static Stack<Exception> exceptions;
		private static Stack<ExceptionDispatchInfo> dispatchInfos;

		public static Exception LastException { get => exceptions.Peek(); }
		public static ExceptionDispatchInfo LastDispatchInfos { get => dispatchInfos.Peek(); }

		public static void SaveException(Exception e)
        {
			exceptions.Push(e);
			dispatchInfos.Push(ExceptionDispatchInfo.Capture(e));
        }

		public static void PrintException(Exception exception, string message = null)
		{
			if (message != null) Console.WriteLine("\n" + message);
			Console.WriteLine(exception.Message);
			Console.WriteLine(exception.StackTrace);
		}
	}
}
