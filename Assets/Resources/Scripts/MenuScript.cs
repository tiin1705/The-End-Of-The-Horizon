using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject MenuPN;
    [SerializeField] GameObject InvenPN;
    [SerializeField] GameObject CanvasSys;
    [SerializeField] GameObject BtnResume;
    [SerializeField] GameObject BtnSetting;
    [SerializeField] GameObject BtnExit;
    [SerializeField] GameObject BtnOpen;
    [SerializeField] GameObject PNSetting;
    [SerializeField] GameObject PNButtonSetExit;
    [SerializeField] GameObject PNButtonSetSave;
    [SerializeField] GameObject PNTitleSavedone;
    [SerializeField] GameObject PNhideTitleSave;
    [SerializeField] GameObject PanelShop;
    [SerializeField] GameObject BtnOPShop;
    public void OpenMenu()
    {
        //if (Input.GetKey(KeyCode.Tab)){
        //    CanvasSys.SetActive(true);
        //    InvenPN.SetActive(false);

        //}
        MenuPN.SetActive(true);
        BtnOpen.SetActive(false);
        
    }
    public void ResumeGame()
    {
        MenuPN.SetActive(false);
        BtnOpen.SetActive(true);
    }
    //----------------------------//
    public void SettingGame()
    {
        BtnResume.SetActive(false);
        BtnExit.SetActive(false);
        BtnSetting.SetActive(false);
        PNSetting.SetActive(true);
    }
    public void SettingExit()
    {
        PNSetting.SetActive(false);
        BtnResume.SetActive(true);
        BtnExit.SetActive(true);
        BtnSetting.SetActive(true);
    }
    public void SettingSave()
    {
        PNTitleSavedone.SetActive(true);
        PNSetting.SetActive(false);
    }
    public void hideTitleSave()
    {
        PNTitleSavedone.SetActive(false);
        BtnResume.SetActive(true);
        BtnExit.SetActive(true);
        BtnSetting.SetActive(true);

    }
    public void hideShop()
    {
        PanelShop.SetActive(true);
        BtnOpen.SetActive(false);
        BtnOPShop.SetActive(false);
        
    }

    //----------------------------//
    public void ExitGame()
    {
        //
    }
}
