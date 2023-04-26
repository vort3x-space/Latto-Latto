using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidderH : MonoBehaviour
{
    public Slider slider;
 

    IEnumerator Start() {
        slider.value = 0.0f;
        float value = 0.0f;
		
        while (value<=100.0f)
        {
            yield return new WaitForSeconds(1.0f);
            UpdateSlider(GameManager.Instance.points);
        }

    }

    void UpdateSlider(float value) {
        slider.value = value;
    }

    void ChangeSlider()
    {
        
    }
	
}