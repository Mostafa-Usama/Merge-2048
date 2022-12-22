using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sound_controller : MonoBehaviour
{
    public Slider slider;
    float volume = 1f;
     GameObject soundmanager;
     AudioSource audiosound;
    // Start is called before the first frame update
    void Start()
    {
        // get the last volume stored
        volume = PlayerPrefs.GetFloat("volume");
        // find sound manger game object
        soundmanager = GameObject.FindWithTag("sound");
        // access its audio source
        audiosound = soundmanager.GetComponent<AudioSource>();
        // set volume to the last volume stored
        audiosound.volume = volume;
        // move slider to this volume level
        slider.value = volume;

    }

    // Update is called once per frame
    void Update()
    {
        // set volume level to the current volume value
        audiosound.volume = volume;
        // save current volume value
        PlayerPrefs.SetFloat("volume", volume);
    }
    public void setVolume(float v)
    {
        // change volume from slider
        volume = v;
    }


}

