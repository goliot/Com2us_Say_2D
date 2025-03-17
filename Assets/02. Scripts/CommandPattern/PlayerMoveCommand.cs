using UnityEngine;

public class PlayerMoveCommand : MonoBehaviour, IPlayerCommand
{
    private PlayerMove _playerMove;
    private Vector2 _direction;
    public float Timestamp { get; private set; }

    public void Execute()
    {
        throw new System.NotImplementedException();
    }

    public void Redo()
    {
        throw new System.NotImplementedException();
    }

    public void Undo()
    {
        throw new System.NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
