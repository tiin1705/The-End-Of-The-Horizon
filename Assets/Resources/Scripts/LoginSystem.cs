using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginSystem : MonoBehaviour
{
    [SerializeField] GameObject PlayButton;
    [SerializeField] GameObject LoginButton;
    [SerializeField] GameObject RegisterButton;
    [SerializeField] GameObject Panels;
    [SerializeField] GameObject CancelPlayButton;
    [SerializeField] GameObject YesPlayButton;
    //-----------------------------------//
    [SerializeField] GameObject Lg_Panel;
    [SerializeField] GameObject Lg_John;
    [SerializeField] GameObject Lg_Cancel;


    public void PlayGame()
    {
        Panels.SetActive(true);
        LoginButton.SetActive(false);
        RegisterButton.SetActive(false);
        
    }
    public void cancelPlay()
    {
        Panels.SetActive(false);
        LoginButton.SetActive(true);
        RegisterButton.SetActive(true);
    }
    public void YesPlay()
    {
        SceneManager.LoadScene(0);
    }
    //----------------------------------//
    public void LoginGame()
    {
        Lg_Panel.SetActive(true);
        RegisterButton.SetActive(false);
        PlayButton.SetActive(false);

    }
    public void LoginJohn()
    {
        //
    }
    public void LoginCancel()
    {
        Lg_Panel.SetActive(false);
        RegisterButton.SetActive(true);
        PlayButton.SetActive(true);
    }
    


}

