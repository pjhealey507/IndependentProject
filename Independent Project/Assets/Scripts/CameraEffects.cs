using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    private bool rewinding = false;
    public Shader gray_shader;

    public void RewindOn()
    {
        rewinding = true;
    }

    public void RewindOff()
    {
        rewinding = false;
    }

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
        Debug.Log("OnRenderImage");

        if (rewinding)
        {
            Graphics.Blit(source, destination, new Material(gray_shader));
        }
	}
}
