using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderColorChange : MonoBehaviour
{

    Color targetColor;
    public Color Kuuma;
    public Color Kylmä;
    public Color Haalea;
    public Image FILL;
    Slider Slider;
    // Use this for initialization
    void Start()
    {
        Slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float value = Slider.value;
        if (value >= 25)
            targetColor = Kuuma;
        if (value <= 10)
            targetColor = Kylmä;
        if (value > 10 && value < 25)
            targetColor = Haalea;

        FILL.color = Color.Lerp(FILL.color, targetColor, Time.deltaTime * 5);
    }
}
