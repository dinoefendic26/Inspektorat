using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    private AudioSource musicAudio;
    public AudioSource sfxAudio;

    public Sprite musicOn, musicOff, soundOn, soundOff;
    public Image music, sound;
    
    void Start()
    {
        musicAudio = this.gameObject.GetComponent<AudioSource>();
    }

    public void MusicButton()
    {
        if(musicAudio.isPlaying)
        {
            musicAudio.Pause();
            music.sprite = musicOff;
        }
        else
        {
            musicAudio.Play();
            music.sprite = musicOn;
        }
    }

    public void SfxButton()
    {
        if(sfxAudio.mute)
        {
            sfxAudio.mute = false;
            sound.sprite = soundOn;
        }
        else
        {
            sfxAudio.mute = true;
            sound.sprite = soundOff;
        }
    } 
}
