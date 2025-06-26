using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameVolum : MonoBehaviour
{
    public AudioMixer audioMixer;
    Slider _volumSlider;

    private void Start()
    {
        _volumSlider = GetComponent<Slider>();
        _volumSlider.onValueChanged.AddListener(SetVolum);
    }

    public void SetVolum (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
