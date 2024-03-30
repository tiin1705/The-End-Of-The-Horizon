using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HoldMenuScript : MonoBehaviour
{
    [SerializeField] GameObject MenuPN;
    [SerializeField] GameObject InvenPN;
    [SerializeField] GameObject CanvasSys;
    [SerializeField] GameObject BtnResume;
    [SerializeField] GameObject BtnSetting;
    [SerializeField] GameObject BtnExit;
    public void ResumeGame()
    {
        CanvasSys.SetActive(false);
    }
    public void SettingGame()
    {
        //
    }
    public void ExitGame()
    {
        //
    }
}

