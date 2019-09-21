using UnityEngine;

public class Cell : MonoBehaviour
{
    private Vector2Int _size;
    
    //TODO: how we can hold state information about the Cell
    // maybe _enableState
    // color array?

    public void Init(Vector2Int size)
    {
        _size = size;
    }
}