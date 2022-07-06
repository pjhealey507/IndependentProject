using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    public UnityEngine.Rendering.VolumeProfile volumeProfile;
    private UnityEngine.Rendering.Universal.ColorAdjustments color_adjust;

    private void Start()
	{
        volumeProfile.TryGet(out color_adjust);
    }

	public void RewindOn()
    {
        color_adjust.saturation.value = -100;
    }

    public void RewindOff()
    {
        color_adjust.saturation.value = 0;
    }
}
