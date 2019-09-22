using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GridManager gridManager;

    private Cube _cube;
    private GridManager _grid;
    private Cell _cubeCell;

    private void Start()
    {
        Init();
        InstantiateCube();
    }

    private void Init()
    {
        gridManager.Init();
        _cubeCell = gridManager.CubeCell;
    }

    private void InstantiateCube()
    {
        var newCube = Instantiate(cubePrefab, _cubeCell.transform.position, Quaternion.identity);
        _cube = newCube.gameObject.GetComponent<Cube>();

        var inputManager = _cube.GetComponent<InputManager>();
        inputManager.OnUp += HandleUp;
        inputManager.OnDown += HandleDown;
        inputManager.OnLeft += HandleLeft;
        inputManager.OnRight += HandleRight;
    }
    
    private void HandleUp()
    {
        var nextCell = gridManager.GetUp(_cubeCell);
        MoveCube(nextCell, Coordinate.Up);
    }
    
    private void HandleDown()
    {
        var nextCell = gridManager.GetDown(_cubeCell);
        MoveCube(nextCell, Coordinate.Down);
    }
    
    private void HandleLeft()
    {
        var nextCell = gridManager.GetLeft(_cubeCell);
        MoveCube(nextCell, Coordinate.Left);
    }
    
    private void HandleRight()
    {
        var nextCell = gridManager.GetRight(_cubeCell);
        MoveCube(nextCell, Coordinate.Right);
    }

    private void MoveCube(Cell nextCell, Coordinate coordinate)
    {
        if (nextCell == null)
        {
            Debug.Log("Cannot move to a null cell");
            return;
        }

        switch (coordinate)
        { 
            case Coordinate.Up:
                _cube.RotateUp();
                break;
            case Coordinate.Down:
                _cube.RotateDown();
                break;
            case Coordinate.Left:
                _cube.RotateLeft();
                break;
            case Coordinate.Right:
                _cube.RotateRight();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(coordinate), coordinate, null);
        }
        //TODO: implement rotating movement
        _cube.transform.position = nextCell.transform.position;
        _cubeCell = nextCell;
        
    }

    private enum Coordinate
    {
        Up,
        Down,
        Left,
        Right
    }

}

