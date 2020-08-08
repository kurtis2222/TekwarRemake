using UnityEngine;
using System.Collections;

public class FaucetScript : IntObj {
	
	GameObject rwater;
	
	void Awake()
	{
		rwater = transform.Find("rwater").gameObject;
	}
	
	public override void Action()
	{
		rwater.particleEmitter.emit = !rwater.particleEmitter.emit;
		if(rwater.particleEmitter.emit) audio.Play();
		else audio.Stop();
	}
}