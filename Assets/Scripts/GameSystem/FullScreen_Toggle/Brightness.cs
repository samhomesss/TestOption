using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Brightness : MonoBehaviour
{
    [SerializeField] Volume volume; // URP Volume containing ColorAdjustments

    Slider _slider;
    ColorAdjustments _colorAdjustments;

    private void Start()
    {
        _slider = GetComponent<Slider>();

        if (volume == null)
        {
            volume = FindObjectOfType<Volume>();
        }

        if (volume != null)
        {
            volume.profile.TryGet(out _colorAdjustments);

            if (_colorAdjustments != null)
            {
                _slider.value = _colorAdjustments.postExposure.value;
            }
        }

        _slider.onValueChanged.AddListener(SetBrightness);
    }

    void SetBrightness(float value)
    {
        if (_colorAdjustments != null)
        {
            _colorAdjustments.postExposure.value = value;
        }
    }
}