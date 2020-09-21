using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelBuilder : MonoBehaviour
{
    public GameObject Grid;
    public GameObject Raw;
    public GameObject LetterTile;

    List<GameObject> TileList = new List<GameObject>();
    public void GenrateLevel(int GridSize,Datum data)
    { 
        for(int i = 0; i < GridSize; i++)
        {
            GameObject raw = GameObject.Instantiate(Raw, Grid.transform) as GameObject;
            for (int j = 0; j < GridSize; j++)
            {
                GameObject tile = GameObject.Instantiate(LetterTile,raw.transform) as GameObject;
                TileList.Add(tile);
            }
        }

        for(int letterIndex = 0; letterIndex < Mathf.Pow(GridSize,2); letterIndex++)
        {
            
            //print(TileList[letterIndex].gameObject.name);
            TileList[letterIndex].gameObject.GetComponentInChildren<TextMeshProUGUI>().text= data.GridData[letterIndex].letter;
            //print(data.GridData[letterIndex].letter);
        }
        
    }

}
