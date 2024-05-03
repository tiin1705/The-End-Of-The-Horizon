using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenUrl : MonoBehaviour
{
    public int coins;
    public Text coinUI;
    public GameObject btnBuy;
    public GameObject btnCheck;
    public GameObject TextSuccess;
    public GameObject TextReview;
    public GameObject PNPuy;
    public GameObject btnclose;

   public void Openurl(string UrlName)
    {
        Application.OpenURL(UrlName);
        PNPuy.SetActive(true);
    }

    public void checking()
    {
        btnCheck.SetActive(false);
        TextReview.SetActive(false);
        TextSuccess.SetActive(true);
        btnclose.SetActive(true);
        coins++;
        coinUI.text = "GEM: " + coins.ToString();
    }
    public void close()
    {
        PNPuy.SetActive(false);
        btnCheck.SetActive(true);
        TextReview.SetActive(true);
        TextSuccess.SetActive(false);
        btnclose.SetActive(false);
        btnBuy.SetActive(true);


    }
    

}
