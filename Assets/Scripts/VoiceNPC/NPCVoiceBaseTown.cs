using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCVoiceBaseTown : MonoBehaviour
{
    [SerializeField] GameObject Voice1;
    [SerializeField] GameObject Voice2;
    [SerializeField] GameObject ButtonVoice1;
    [SerializeField] GameObject ButtonVoice2;
    [SerializeField] GameObject ButtonACPTNPC;
    [SerializeField] GameObject NPCVoicePanel;
    [SerializeField] GameObject ImageNPC;
    [SerializeField] GameObject NameNPC;
    //----------------------------
    [SerializeField] GameObject ImageNPCWZ;
    [SerializeField] GameObject NameNPCWZ;
    [SerializeField] GameObject VoiceWZ1;
    [SerializeField] GameObject VoiceWZ2;
    [SerializeField] GameObject VoiceWZ3;
    [SerializeField] GameObject ButtonVoiceWZ1;
    [SerializeField] GameObject ButtonVoiceWZ2;
    [SerializeField] GameObject ButtonACPTNPCWZ;
    [SerializeField] GameObject ButtonACPTNPCWZhideChar;

    private void Update()
    {
        
    }
    public void OnClickVoiceNPC()
    {
        NPCVoicePanel.SetActive(true);
    }
    public void OnClickVoiceNPC1() {
        Voice1.SetActive(false);
        ButtonVoice1.SetActive(false);
        ButtonVoice2.SetActive(false);
        Voice2.SetActive(true);
        ButtonACPTNPC.SetActive(true);
    }
    public void OnClickClVoice()
    {
        NPCVoicePanel.SetActive(false);
    }
    public void OnclickACP()
    {
        NPCVoicePanel.SetActive(false);
        Voice1.SetActive(true);
        ButtonVoice1.SetActive(true);
        ButtonVoice2.SetActive(true);
        Voice2.SetActive(false);
        ButtonACPTNPC.SetActive(false);

    }


    //-------------------------------------------
    public void OnClickVoiceNPC2()
    {
        NPCVoicePanel.SetActive(true);
        ImageNPC.SetActive(false);
        NameNPC.SetActive(false);
        //..........................
        Voice1.SetActive(false);
        ButtonVoice1.SetActive(false);
        ButtonVoice2.SetActive(false);
        //.............................
        ImageNPCWZ.SetActive(true);
        NameNPCWZ.SetActive(true);
        VoiceWZ1.SetActive(true);
        ButtonVoiceWZ1.SetActive(true);
        ButtonVoiceWZ2.SetActive(true);

    }
    //thoai ve minh than
    public void OnclickVoidNPCWZ2()
    {
        VoiceWZ2.SetActive(true);
        VoiceWZ1.SetActive(false);
        ButtonVoiceWZ1.SetActive(false);
        ButtonVoiceWZ2.SetActive(false);
        ButtonACPTNPCWZ.SetActive(true);
    }
    // chap nhan phuoc lanh
    public void OnClickACPWZ()
    {
        ImageNPCWZ.SetActive(false);
        NameNPCWZ.SetActive(false);
        VoiceWZ1.SetActive(false);
        VoiceWZ2.SetActive(false);
        VoiceWZ3.SetActive(false);
        ButtonVoiceWZ1.SetActive(false);
        ButtonVoiceWZ2.SetActive(false);
        //..........................
        NPCVoicePanel.SetActive(false);
        ImageNPC.SetActive(true);
        NameNPC.SetActive(true);
        //..........................
        Voice1.SetActive(true);
        ButtonVoice1.SetActive(true);
        ButtonVoice2.SetActive(true);
        
    }
    // thoai an
    public void OnClickACPHide()
    {
        VoiceWZ3.SetActive(true);
        VoiceWZ2.SetActive(false);
        VoiceWZ1.SetActive(false);
        ButtonVoiceWZ1.SetActive(false);
        ButtonVoiceWZ2.SetActive(false);
        ButtonACPTNPCWZhideChar.SetActive(true);
        
    }
    public void CACHideEvent()
    {
        ImageNPCWZ.SetActive(false);
        NameNPCWZ.SetActive(false);
        VoiceWZ1.SetActive(false);
        VoiceWZ2.SetActive(false);
        VoiceWZ3.SetActive(false);
        ButtonVoiceWZ1.SetActive(false);
        ButtonVoiceWZ2.SetActive(false);
        ButtonACPTNPCWZhideChar.SetActive(false);
        //..........................
        NPCVoicePanel.SetActive(false);
        ImageNPC.SetActive(true);
        NameNPC.SetActive(true);
        //..........................
        Voice1.SetActive(true);
        ButtonVoice1.SetActive(true);
        ButtonVoice2.SetActive(true);
    }

}
