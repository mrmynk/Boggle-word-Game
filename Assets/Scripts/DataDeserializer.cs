using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Better.StreamingAssets;

public class DataDeserializer : MonoBehaviour
{
    public string JSONFileName;
    [HideInInspector]
    
    //Json Data
    string jsonPath;
    string jsonStrng; 
    LevelData Leveldata;

    public LevelData Levels
    {
        get
        {
            return Leveldata;
        }
    }

    //Wordlist Data
    public string wordListFileName;
    string wordPath;
    public List<string> wordList = new List<string>();

    
    private void Awake()
    {
        ReadJson(JSONFileName);
        ReadWordList(wordListFileName);

    }

    private void ReadWordList(string fileName)
    {
        
        string[] lines=BetterStreamingAssets.ReadAllLines("/"+fileName+".txt");
        foreach(string word in lines)
        {
            wordList.Add(word);
        }
        
    }

    private void ReadJson(string fileName)
    {
        
        var settings = new JsonSerializerSettings();
        BetterStreamingAssets.Initialize();


        #if UNITY_EDITOR
        //jsonPath = Application.streamingAssetsPath + "/"+fileName+".json";
        #endif
         
        //jsonStrng = File.ReadAllText(jsonPath);
        jsonStrng = BetterStreamingAssets.ReadAllText("/" + fileName + ".json");
        if (jsonStrng != null)
        {
            Leveldata = JsonConvert.DeserializeObject<LevelData>(jsonStrng, settings);
        }
        else
        {
            Debug.Log("JSON File not found ");
        }
      
    }
}
