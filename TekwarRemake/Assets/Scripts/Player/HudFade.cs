using UnityEngine;
using System.Collections;

public class HudFade : MonoBehaviour
{
	System.Action hndl;
	Color col;
	bool fading;
	
	public void Init(System.Action hndl)
	{
		this.hndl = hndl;
		col = guiTexture.color;
	}
	
	public void Fade()
	{
		if(fading) return;
		guiTexture.enabled = true;
		fading = true;
		enabled = true;
	}
	
	public void Update()
	{
		col.a += 0.01f;
		guiTexture.color = col;
		if(col.a >= 1.0f)
		{
			enabled = false;
			hndl();
		}
	}
}