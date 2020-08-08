using UnityEngine;
using System.Collections;

public class ParticleScript3 : MonoBehaviour {

	public float time = 1f;
	public AudioClip sound;
	
	void Start ()
	{
		if(sound != null)
		{
			audio.pitch = Random.Range(0.9f,1.1f);
			audio.PlayOneShot(sound);
		}
		StartCoroutine(AutoDestroy());
	}
	
	IEnumerator AutoDestroy()
	{
		yield return new WaitForSeconds(sound.length);
		Destroy(gameObject);
	}
}