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
    [SerializeField] GameObject TextLogin;
    [SerializeField] GameObject TextRegister;
    //-----------------------------------//
    [SerializeField] GameObject Lg_Panel;
    [SerializeField] GameObject Lg_John;
    [SerializeField] GameObject Lg_Cancel;
    //[SerializeField] GameObject Lg_TextName;
    //[SerializeField] GameObject Lg_TextPass;
    //----------------------------------//
    [SerializeField] GameObject Re_Panel;
    [SerializeField] GameObject Re_Create;
    [SerializeField] GameObject Re_Cancel;


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
        SceneManager.LoadScene(3);
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
        SceneManager.LoadScene(3);
    }
    public void LoginCancel()
    {
        Lg_Panel.SetActive(false);
        RegisterButton.SetActive(true);
        PlayButton.SetActive(true);
        Re_Panel.SetActive(false);
    }
    //------------------------------------//
    public void RegisterGame()
    {
        Re_Panel.SetActive(true);
        LoginButton.SetActive(false);
        PlayButton.SetActive(false);

    }
    public void RegisterDone() {
        RegisterButton.SetActive(false);
        LoginButton.SetActive(true);
        Lg_Panel.SetActive(true);
        TextLogin.SetActive(false);
        TextRegister.SetActive(true);
    }
    public void cancelRes()
    {
        Re_Panel.SetActive(false);
        LoginButton.SetActive(true);
        PlayButton.SetActive(true); 
    }



}

