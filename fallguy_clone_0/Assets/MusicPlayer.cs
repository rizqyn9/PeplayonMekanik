using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public Slider ss;
    public AudioSource sound;
    public AudioSource beat;
    public AudioSource BGMGAME;
    private float musicVolume = 1f;
    public bool BGMINGAME;
    public bool InGame;
    public bool MainMenu;
    public bool notplaying;
    public bool isnotplaying;
    private bool sorak = true;

    private void Start()
    {
        if (MainMenu)
        {
            beat.Play();
        }
    }

    private void playsorak()
    {
        if (sorak)
        {
            sorak = false;
            sound.Play();
            Debug.Log("Sorak");
        }
    }

    private void Update()
    {
        sound.volume = musicVolume;
        beat.volume = musicVolume;
        BGMGAME.volume = musicVolume;

        if (MainMenu)
        {
            if (beat.isPlaying)
            {
                Invoke("playsorak", 1);
            }
        }

        if (InGame)
        {
            if (BGMINGAME)
            {
                if (!isnotplaying)
                {
                    isnotplaying = true;
                    BGMGAME.Play();
                }
            }
        }

        UpdateVolume();
    }

    public void UpdateVolume()
    {
        musicVolume = ss.value;
    }
}