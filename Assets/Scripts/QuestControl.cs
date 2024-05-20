using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestControl : MonoBehaviour
{
    public GameObject NPCChat1;
    public GameObject NPCChat2;
    public GameObject NPCChat3;
    public GameObject NPCChat4;
    public GameObject Q1;
    public GameObject Q2;
    public GameObject Q3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            NPCChat1.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            NPCChat1.SetActive(false);
            NPCChat2.SetActive(false);
            NPCChat3.SetActive(false);

        }
    }


}
