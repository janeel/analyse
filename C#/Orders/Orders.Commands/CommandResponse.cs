namespace Orders.Commands;

public class CommandResponse
{
    public int Id { get; }
    public string Error { get; }

    public bool Success => !String.IsNullOrWhiteSpace(Error);

    private CommandResponse(int id)
    {
        Id = id;
    }

    private CommandResponse(string error)
    {
        Error = error;
    }

    public static CommandResponse MakeForError(string error)
    {
        return new CommandResponse(error);
    }
    
    public static CommandResponse MakeWithId(int id)
    {
        return new CommandResponse(id);
    }
    
    
}