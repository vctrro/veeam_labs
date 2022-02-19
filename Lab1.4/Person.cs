using System;
using System.Text.RegularExpressions;

namespace Lab1_4_String_Exception
{
	public class Person
	{
		private Person()
		{
		}

        private string phoneNumber;
        private readonly Regex validNumber = new(@"^\+?[0-9]{1,3}\ ?\(?[0-9]{3}\)?\ ?[0-9]{3}[- ]?[0-9]{2}[- ]?[0-9]{2}$");

        public string Name { get; init; }
        public string PhoneNumber
        {
            get => phoneNumber;
			set
            {
                phoneNumber = validNumber.IsMatch(value) ? value : throw new NotANumberException();
            }
        }

        public static Person CreatePerson(string name, string phone)
        {
            try
            {
                return new Person() { Name = name, PhoneNumber = phone };
            }
            catch (NotANumberException nanEx)
            {
                ExceptionHandler.SaveException(nanEx);
                ExceptionHandler.PrintException(nanEx, "Exception in new Person()");

                //throw;
                //throw nanEx;
                Exception e = new("Throw new in catch. ", nanEx);
                throw e;
            }
        }
    }
}

