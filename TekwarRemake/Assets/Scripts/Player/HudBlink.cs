using UnityEngine;
using System.Collections;

public class HudBlink : MonoBehaviour
{
	System.Action hndl;
	bool blinking;
	
	public void Init(System.Action hndl)
	{
		this.hndl = hndl;
	}
	
	public void Blink()
	{
		if(blinking) return;
		guiTexture.enabled = true;
		blinking = true;
		hndl();
		StartCoroutine(ResetBlink());
	}
	
	IEnumerator ResetBlink()
	{
		yield return new WaitForSeconds(0.2f);
		guiTexture.enabled = false;
		blinking = false;
	}
}