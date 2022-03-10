namespace ConsoleApp8
{
    internal class NumberException : Exception
    {
        override public string Message
        {
            get { return "This is not a number. Error!"; }
        }
    }
}
