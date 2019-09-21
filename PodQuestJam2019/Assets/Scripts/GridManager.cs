using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;

    private List<Cell> _grid = new List<Cell>();

    // TODO: consider a ScriptableObject to hold GridInformation
    [SerializeField] private Vector2Int size;
    
    private void Start()
    {
        InitGrid();
    }

    private void InitGrid()
    {
        var offset = new Vector3(-(float)size.x/2, 0, -(float)size.y/2);
        
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                var newGameObject = Instantiate(_cellPrefab, new Vector3(x, 0, y) + offset, Quaternion.Euler(0, 0, 0), transform);
                var newCell = newGameObject.GetComponent<Cell>();
                newGameObject.name = $"Cell{x}x{y}";
                _grid.Add(newCell);
            }
        }
    }
    
}
