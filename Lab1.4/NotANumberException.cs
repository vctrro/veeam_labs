using System;
namespace Lab1_4_String_Exception
{
	[Serializable]
	public class NotANumberException : ArgumentException
	{
		public NotANumberException(string message) : base(message)
		{
		}

		public NotANumberException()
			: base("The entered value is not a phone number")
		{
		}
    }
}

