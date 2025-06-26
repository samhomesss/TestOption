using UnityEngine;
using UnityEngine.UI;

public class FullScreenToggle : MonoBehaviour
{
    Toggle _fullScreen;

    void Start()
    {
        _fullScreen = GetComponent<Toggle>();
        _fullScreen.isOn = Screen.fullScreen; // ���� ���� �ݿ�
        _fullScreen.onValueChanged.AddListener(OnFullScreenToggle);
    }

    void OnFullScreenToggle(bool isOn)
    {
        Screen.fullScreen = isOn;
    }
}
