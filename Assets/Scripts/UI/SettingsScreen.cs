using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{
    [SerializeField] private int mainMenuScene;
    [SerializeField] private Toggle soundToggle;
    [SerializeField] private Toggle musicToggle;

    public static Action <bool> MusicPlay;

    private void Start()
    {
        soundToggle.isOn = !PersistanceData.isSound;
        musicToggle.isOn = !PersistanceData.isMusic;
    }
    public void BackToMainMenuButton()
    {
        PersistanceData.SaveData();
        SceneManager.LoadScene(mainMenuScene);
    }

    public void SoundChange()
    {
        PersistanceData.isSound = !soundToggle.isOn;
    }

    public void MusicChange()
    {
        PersistanceData.isMusic = !musicToggle.isOn;
        MusicPlay?.Invoke(!musicToggle.isOn);
    }


}
