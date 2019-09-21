using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

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
        _cubeCell = gridManager.GetRandomCell();
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
        MoveCube(nextCell);
    }
    
    private void HandleDown()
    {
        var nextCell = gridManager.GetDown(_cubeCell);
        MoveCube(nextCell);
    }
    
    private void HandleLeft()
    {
        var nextCell = gridManager.GetLeft(_cubeCell);
        MoveCube(nextCell);
    }
    
    private void HandleRight()
    {
        var nextCell = gridManager.GetRight(_cubeCell);
        MoveCube(nextCell);
    }

    private void MoveCube(Cell nextCell)
    {
        if (nextCell == null)
        {
            Debug.Log("Cannot move to a null cell");
            return;
        }
        
        //TODO: implement rotating movement
        _cube.transform.position = nextCell.transform.position;
        _cubeCell = nextCell;
    }
}
