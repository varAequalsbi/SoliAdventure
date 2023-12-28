using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class NpcDialog : MonoBehaviour
{
    [SerializeField] private GameObject DialogPanel;
    [SerializeField] private TextMeshProUGUI DialogText;
    [SerializeField] string[] Dialog;
    private int index;
    private bool Clicked = true;
    

    [SerializeField] private GameObject ConButton;
    [SerializeField] private float wordspeed;
    [SerializeField] private bool IsplayerClose;


    private void Update()
    {
        if (IsplayerClose && Input.GetKeyDown(KeyCode.E))
        {

            if (DialogPanel.activeInHierarchy)
            {
                NoText();
            }
            else
            {
                DialogPanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (DialogText.text == Dialog[index])
        {
            ConButton.SetActive(true);
        }
    }

    public void butonE () {
        if (IsplayerClose && Clicked)
        {
            Clicked = false;
        DialogPanel.SetActive(true);
        StartCoroutine(Typing());    
        }
    }

    public void NoText()
    {
        Clicked = true;
        DialogText.text = "";
        index = 0;
        DialogPanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in Dialog[index].ToCharArray())
        {
            DialogText.text += letter;
            yield return new WaitForSeconds(wordspeed);
        }
    }

    public void NextLine()
    {
        ConButton.SetActive(false);

        if(index < Dialog.Length - 1)
        {
            index++;
            DialogText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            NoText() ;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsplayerClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsplayerClose = false;
            NoText();
        }
    }

}
