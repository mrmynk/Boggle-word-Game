using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class LetterSelector : MonoBehaviour
{
    private GameObject selectionSprite;
    GameObject selectLetter;
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    WordChecker wordChecker;
    TextMeshProUGUI letter;
    bool isAlreadyIntoTheWord = false;

    void Start()
    {

        m_Raycaster = GameObject.FindObjectOfType<GraphicRaycaster>();
        m_EventSystem = GameObject.FindObjectOfType<EventSystem>();
        wordChecker= GameObject.FindObjectOfType<WordChecker>();

        selectionSprite = transform.GetChild(1).gameObject;
        selectionSprite.SetActive(false);
    }

    [System.Obsolete]
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //wordChecker.ClearWord();
            
            
        }
        if (Input.GetMouseButton(0))
        {
            selectLetter = pointer();
            if (!(selectLetter.transform.parent.GetChild(1).gameObject.active))
            {
                highlightSelection();
                AddLetterToWord();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectionSprite.SetActive(false);
            wordChecker.CheckWord();
            wordChecker.ClearWord();
            
        }
    
    }

    private void highlightSelection()
    { 
        selectLetter.transform.parent.GetChild(1).gameObject.SetActive(true);
    }

    private void AddLetterToWord()
    {
        letter = selectLetter.transform.parent.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        wordChecker.AppendWord(letter.text);
        
    }

    GameObject pointer()
    {
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        m_Raycaster.Raycast(m_PointerEventData, results);

        return results[1].gameObject;
    }

    
}
