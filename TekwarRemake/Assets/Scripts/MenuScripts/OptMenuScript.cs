using UnityEngine;
using System.Collections;

public class OptMenuScript : MonoBehaviour
{
	public GameObject main_cam;
	public AudioClip menu_snd;
	public GameObject main_menu;
	public ConfigLoader cfg;
	
	void OnMouseEnter()
	{
		renderer.material.color = Color.red;
		main_cam.audio.PlayOneShot(menu_snd);
	}
	
	void OnMouseExit()
	{
		renderer.material.color = Color.white;
	}
	
	void OnMouseDown()
	{
		renderer.material.color = Color.white;
		cfg.DoSave();
		main_menu.SetActiveRecursively(true);
		transform.parent.gameObject.SetActiveRecursively(false);
	}
}