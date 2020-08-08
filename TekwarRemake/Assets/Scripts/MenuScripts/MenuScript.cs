using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour
{
	public GameObject main_cam;
	public AudioClip menu_snd;
	public int menuid = 0;
	public GameObject opt_menu;
	
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
		if(menuid == 0)
		{
			transform.parent.gameObject.SetActiveRecursively(false);
			opt_menu.renderer.enabled = true;
			Application.LoadLevel((int)GameBase.Levels.Marty1);
		}
		else if(menuid == 1)
		{
			transform.parent.gameObject.SetActiveRecursively(false);
			opt_menu.SetActiveRecursively(true);
		}
		else Application.Quit();
	}
}