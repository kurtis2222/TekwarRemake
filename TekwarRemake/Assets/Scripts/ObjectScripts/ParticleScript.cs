using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {

	public float time = 1f;
	public AudioClip sound;
	
	void Start ()
	{
		if(sound != null)
		{
			audio.pitch = Random.Range(0.9f,1.1f);
			audio.PlayOneShot(sound);
			StartCoroutine(AutoDestroy());
		}
		StartCoroutine(HideMesh());
	}
	
	IEnumerator HideMesh()
	{
		yield return new WaitForSeconds(time);
		System.Array.ForEach(gameObject.GetComponentsInChildren<Renderer>(),x => x.enabled = false);
		if(sound == null) Destroy(gameObject);
	}
	
	IEnumerator AutoDestroy()
	{
		yield return new WaitForSeconds(sound.length);
		Destroy(gameObject);
	}
}