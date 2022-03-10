namespace ConsoleApp8
{
    internal class Message
    {
        public Message(string text)
        {
            Text = text;
        }

        public virtual void Print() 
        {
            Console.WriteLine($"Message: {this.Text}");
        }

        public string Text { get; }
    }
}
