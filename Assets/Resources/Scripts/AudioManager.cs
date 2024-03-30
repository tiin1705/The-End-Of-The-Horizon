using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audio_scr1;
    [SerializeField] AudioSource audio_src2;
    [SerializeField] AudioSource audio_src3;
    public void PlaySoundButton()
    {
        audio_scr1.Play();  
    }
    public void PlaySoundCancel()
    {
        audio_src2.Play();
    }
    public void PlaySoundsuccess()
    {
        audio_src3.Play();
    }

}
