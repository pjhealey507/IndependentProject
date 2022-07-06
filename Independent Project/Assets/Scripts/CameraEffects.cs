using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    public UnityEngine.Rendering.VolumeProfile volumeProfile;
    private UnityEngine.Rendering.Universal.ColorAdjustments color_adjust;

    private int hue_shift_reduce_rate = 10;

    private void Start()
	{
        volumeProfile.TryGet(out color_adjust);
    }

	private void Update()
	{
        //Move hue shift towards 0 
        color_adjust.hueShift.value -= (hue_shift_reduce_rate * Time.deltaTime);
        if (color_adjust.hueShift.value <= 0)
        {
            color_adjust.hueShift.value = 0;
        }
	}

	public void RewindOn()
    {
        //Lower saturation, creates a black and white effect
        color_adjust.saturation.value = -100;
    }

    public void RewindOff()
    {
        //set saturation back to normal
        color_adjust.saturation.value = 0;
    }

    public void PlayerDamaged()
    {
        color_adjust.hueShift.value += 20;
    }
}
