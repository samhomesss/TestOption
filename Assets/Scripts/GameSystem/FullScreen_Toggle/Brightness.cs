using UnityEngine;
using UnityEngine.UI;

public class Brightness : MonoBehaviour
{
    Slider _slider;
    private void Start()
    {
        _slider = GetComponent<Slider>();
    }
}
