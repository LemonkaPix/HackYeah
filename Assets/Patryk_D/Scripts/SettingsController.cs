using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{

    
    [SerializeField] PlayerData playerData;
    [SerializeField] GameObject volume;
    [SerializeField] GameObject fullscreen;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setVolume() {
        float aVolume = volume.GetComponent<Slider>().value;
        playerData.volume = aVolume;
        AudioListener.volume = aVolume;
    }

    public void toggleFullscreen() {
        bool aToggle = fullscreen.GetComponent<Toggle>().isOn;
        playerData.Fullscreen = aToggle;
        Screen.fullScreen = !Screen.fullScreen;
    }
}
