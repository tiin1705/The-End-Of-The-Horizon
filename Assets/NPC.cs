using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{

    public GameObject NPCPanel;
    public Text NPCText;
    public string[] NPCLogue;
    private int index;
    public GameObject contButton; 

    public float wordSpeed;
    public bool playerIsClose;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && playerIsClose)
        {
            if (NPCPanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                NPCPanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if(NPCText.text == NPCLogue[index])
        {
            contButton.SetActive(true);
        }
    }


    public void zeroText()
    {
        NPCText.text = "";
        index = 0;
        NPCPanel.SetActive(false);
    }


    IEnumerator Typing()
    {
        foreach(char letter in NPCLogue[index].ToCharArray())
        {
            NPCText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        contButton.SetActive(false);
        if(index < NPCLogue.Length - 1)
        {
            index++;
            NPCText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
