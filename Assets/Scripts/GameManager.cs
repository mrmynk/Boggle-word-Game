using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    [Range(3,4)]
    private int GridSize;

    DataDeserializer deserialedData;
    LevelBuilder levelBuilder;

    private List<Datum> GridList = new List<Datum>();

    private void Awake()
    {
        deserialedData = GetComponent<DataDeserializer>();
        levelBuilder = GetComponent<LevelBuilder>();
    }
    private void Start()
    {
        ExtractGridSizeData();
        if (GridList.Count == 0)
        {
            Debug.Log("Grid is Empty");
        }
        else
        {
            levelBuilder.GenrateLevel(GridSize, GridList[Convert.ToInt32(Random.Range(0, GridList.Count))]);
        }
    }

    private void ExtractGridSizeData()
    {
        foreach (Datum _data in deserialedData.Levels.Data)
        {
            if (_data.gridSize.x == GridSize && _data.gridSize.y == GridSize)
            {
                GridList.Add(_data);
            }
        }
        
    }
}
