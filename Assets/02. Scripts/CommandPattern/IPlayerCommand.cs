public interface IPlayerCommand
{
    void Execute();
    void Redo();
    void Undo();
    float Timestamp { get; }
}
