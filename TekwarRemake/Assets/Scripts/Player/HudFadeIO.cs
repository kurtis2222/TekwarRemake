using UnityEngine;
using System.Collections;

public class HudFadeIO : MonoBehaviour
{
	Color col;
	bool fading;
	bool back;
	
	public void Awake()
	{
		col = guiTexture.color;
		back = false;
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
		col.a += back ? -0.01f : 0.01f;
		guiTexture.color = col;
		if(!back && col.a >= 1.0f)
		{
			back = true;
		}
		else if(back && col.a <= 0.0f)
		{
			enabled = false;
			back = false;
			fading = false;
			guiTexture.enabled = false;
		}
	}
}