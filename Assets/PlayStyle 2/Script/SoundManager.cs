using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] GameObject soundOnIcon;
    [SerializeField] GameObject soundOffIcon;
    bool isMuted;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("isMuted"))
        {
            PlayerPrefs.SetInt("isMuted", 0);
            Load();
        }
        else
        {
            Load();
        }
        setIcon();
        AudioListener.pause = isMuted;
    }

    public void OnButtonPress()
    {
        if (isMuted == true)
        {
            isMuted = false;
            AudioListener.pause = false;
        }
        else
        {
            isMuted = true;
            AudioListener.pause = true;
        }
        Save();
        setIcon();
    }
    void setIcon()
    {
        if (isMuted == false)
        {
            soundOffIcon.SetActive(false);
            soundOnIcon.SetActive(true);
        }
        else
        {
            soundOffIcon.SetActive(true);
            soundOnIcon.SetActive(false);
        }
    }
    void Load()
    {
        int t = PlayerPrefs.GetInt("isMuted");
        Debug.Log(t);
        isMuted = PlayerPrefs.GetInt("isMuted") == 1;
    }
    void Save()
    {
        PlayerPrefs.SetInt("isMuted", isMuted ? 1 : 0);
        int t = PlayerPrefs.GetInt("isMuted");
        Debug.Log(t);
    }

}
