using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject _cellPrefab;

    private List<Cell> _grid = new List<Cell>();
    private Cell _cubeCell;
    
    // TODO: consider a ScriptableObject to hold GridInformation
    [SerializeField] private Vector2Int size;

    public List<Cell> Grid => _grid;

    public Cell CubeCell 
    {
        get => _cubeCell;
        set => _cubeCell = value;
    }
    
    public void Init()
    {
        var offset = new Vector3(-(float)size.x/2, 0, -(float)size.y/2);
        
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                var newGameObject = Instantiate(_cellPrefab, new Vector3(x, 0, y) + offset, Quaternion.Euler(0, 0, 0), transform);
                var newCell = newGameObject.GetComponent<Cell>();
                newCell.Init(x, y);
                newGameObject.name = $"Cell{x}x{y}";
                _grid.Add(newCell);
            }
        }

        _cubeCell = GetRandomCell();
    }

    public Cell GetRandomCell()
    {
        var randomIndex = Random.Range(0, _grid.Count);
        return _grid[randomIndex];
    }

    /// <summary>
    /// Try get all 4 neighbor cells. Can return null elements.
    /// </summary>
    public Neighbors GetNeighbors(Cell cell)
    {
        var neighbors = new Neighbors();
        var position = cell.Position;

        neighbors.Up = _grid.Find(x => x.Position == position + Vector2Int.up);
        neighbors.Down = _grid.Find(x => x.Position == position + Vector2Int.down);
        neighbors.Left = _grid.Find(x => x.Position == position + Vector2Int.left);
        neighbors.Right = _grid.Find(x => x.Position == position + Vector2Int.right);
        
        return neighbors;
    }
    
    public Cell GetUp(Cell cell) => _grid.Find(x => x.Position == cell.Position + Vector2Int.up);
    public Cell GetDown(Cell cell) => _grid.Find(x => x.Position == cell.Position + Vector2Int.down);
    public Cell GetLeft(Cell cell) => _grid.Find(x => x.Position == cell.Position + Vector2Int.left);
    public Cell GetRight(Cell cell) => _grid.Find(x => x.Position == cell.Position + Vector2Int.right);

}
