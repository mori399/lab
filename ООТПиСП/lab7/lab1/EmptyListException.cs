namespace lab1;
public class EmptyListException : Exception
{
    public EmptyListException(string message)
        : base(message)
    {
        Console.WriteLine(message);
    }

    public EmptyListException(string message, Exception inner)
        : base(message, inner)
    {
        Console.WriteLine(message);
    }
}