using System.Collections.Generic;
using UnityEngine;
using TMPro; // 중요: TextMeshPro 네임스페이스

public class ScreenDropDown : MonoBehaviour
{
    Resolution[] resolutions;
    TMP_Dropdown _resolutionDropDown;

    void Start()
    {
        _resolutionDropDown = GetComponent<TMP_Dropdown>();

        resolutions = Screen.resolutions;
        _resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i; 
            }
        }

        _resolutionDropDown.AddOptions(options);
        _resolutionDropDown.value = currentResolutionIndex;
        _resolutionDropDown.RefreshShownValue();

        _resolutionDropDown.onValueChanged.AddListener(SetResolution);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width , resolution.height , Screen.fullScreen);
    }
}
