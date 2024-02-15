using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    List<Resolution> resolutions = new();
    public TMP_Dropdown resDrop;
    public Slider sendSlider;
    private void Start()
    {
        SetRez();
    }
    public void Fullscreen(bool toggle)
    {
        Screen.fullScreen = toggle;
    }
    public void SetRez()
    {
        Resolution[] tempRez = Screen.resolutions.Select(res => new Resolution { width = res.width, height = res.height }).Distinct().ToArray();
        for (int i = tempRez.Length - 1; i > 0; i--)
        {
            resolutions.Add(tempRez[i]);
        }
        resDrop.ClearOptions();

        List<string> options = new();
        for (int i = 0; i < resolutions.Count; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
        }
        resDrop.AddOptions(options);
        resDrop.value = 0;
        resDrop.RefreshShownValue();

        Screen.SetResolution(resolutions[0].width, resolutions[0].height, true);
    }
    public void ChangeRez()
    {
        Screen.SetResolution(resolutions[resDrop.value].width, resolutions[resDrop.value].height, Screen.fullScreen);
    }
}
