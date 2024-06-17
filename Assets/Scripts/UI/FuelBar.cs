using UnityEngine;
using UnityEngine.UI;

// https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=240s
public class FuelBar : MonoBehaviour
{
    
    public Slider slider;

    public void SetMaxFuel(float fuel)
    {
        slider.maxValue = fuel;
        slider.value = fuel;
    }

    public void SetFuel(float fuel)
    {
        slider.value = fuel;
    }
}
