using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WordChecker : MonoBehaviour
{
    public TextMeshProUGUI UserWord;
    DataDeserializer dataDeserializer;
    ScoreManager scoreMnager;

    List<string> list;
    private void Awake()
    {
        dataDeserializer = GetComponent<DataDeserializer>();
        scoreMnager = GetComponent<ScoreManager>();
    }
    private void Start()
    {
        list = new List<string>(dataDeserializer.wordList);
        ClearWord();
    }
    public void ClearWord()
    {
        UserWord.text = "";
        UserWord.color = Color.white;
    }

    public void AppendWord(string letter)
    {

        UserWord.text += letter;
     
    }

    public void CheckWord()
    {
        foreach (string word in list)
        {
            if (word.Equals(UserWord.text.ToLower()))
            {
                print(UserWord.text);
                UserWord.color = Color.green;
                scoreMnager.AddScore(UserWord.text.Length);
                list.Remove(word);
            }
            else if(!(word.Equals(UserWord.text.ToLower())))
            {
                UserWord.color = Color.red;
            }
        }
    }
}
