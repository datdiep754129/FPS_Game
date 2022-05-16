using System.Collections;
using System.Collections.Generic;
using Unity.FPS.AI;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public Slider slider;
    private void Update()
    {
        int currentValue = EXPManager.expManager.currentXP;
        int maxEXP = EXPManager.expManager.targetXP;
        slider.value = currentValue;
        slider.maxValue = maxEXP;

    }
}
