using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenDropDown : MonoBehaviour
{
    TMP_Dropdown _resolutionDropDown;
    List<Resolution> uniqueResolutions = new List<Resolution>();

    void Start()
    {
        _resolutionDropDown = GetComponent<TMP_Dropdown>();
        _resolutionDropDown.ClearOptions();

        Resolution[] resolutions = Screen.resolutions;
        HashSet<string> seen = new HashSet<string>();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string resString = resolutions[i].width + "X" + resolutions[i].height;

            // 중복 제거
            if (!seen.Contains(resString))
            {
                seen.Add(resString);
                options.Add(resString);
                uniqueResolutions.Add(resolutions[i]);

                if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = uniqueResolutions.Count - 1;
                }
            }
        }

        _resolutionDropDown.AddOptions(options);
        _resolutionDropDown.value = currentResolutionIndex;
        _resolutionDropDown.RefreshShownValue();

        _resolutionDropDown.onValueChanged.AddListener(SetResolution);
    }

    public void SetResolution(int index)
    {
        Resolution res = uniqueResolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
        Debug.Log($"Resolution set to: {res.width} x {res.height}");
    }
}
