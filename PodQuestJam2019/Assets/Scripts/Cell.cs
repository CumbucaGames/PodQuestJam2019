using UnityEngine;

public class Cell : MonoBehaviour
{
    private Vector2Int _position;
    
    //TODO: how we can hold state information about the Cell
    // maybe _enableState
    // color array?

    public Vector2Int Position { get; set; }
    
    public void Init(int x, int y)
    {
        Init(new Vector2Int(x, y));
    }
    
    public void Init(Vector2Int position)
    {
        _position = position;
    }

    public override string ToString()
    {
        return $"Cell_{Position.ToString()}";
    }
}
