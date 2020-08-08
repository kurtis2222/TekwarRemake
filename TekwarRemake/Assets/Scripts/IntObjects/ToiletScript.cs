using UnityEngine;
using System.Collections;

public class ToiletScript : IntObj {
	
	public AudioClip flush_snd;
	bool flushing = false;
	GameObject rwater;
	
	void Awake()
	{
		rwater = transform.Find("rwater").gameObject;
	}
	
	public override void Action()
	{
		if(!flushing)
		{
			flushing = true;
			audio.PlayOneShot(flush_snd);
			rwater.particleEmitter.emit = true;
			StartCoroutine(ResetToilet());
		}
	}
	
	IEnumerator ResetToilet()
	{
		yield return new WaitForSeconds(5.0f);
		flushing = false;
		rwater.particleEmitter.emit = false;
	}
}