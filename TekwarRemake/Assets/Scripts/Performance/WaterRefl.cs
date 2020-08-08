using UnityEngine;
using System.Collections;

public class WaterRefl : MonoBehaviour
{
	public Renderer[] waters;
	public Material[] mat = new Material[2];
	
	void FixedUpdate()
	{
		Vector3 pos = GameBase.inst.player_tr.position;
		foreach(Renderer r in waters)
		{
			if(Vector3.Distance(r.transform.position,pos) < 24.0f)
			{
				if(r.material != mat[0])
				{
					r.material = mat[0];
					r.GetComponent<Water>().enabled = true;
				}
			}
			else
			{
				if(r.material != mat[1])
				{
					r.GetComponent<Water>().enabled = false;
					r.material = mat[1];
				}
			}
		}
	}
	
	public void DisableReflWater()
	{
		enabled = false;
		foreach(Renderer r in waters)
		{
			r.GetComponent<Water>().enabled = false;
			r.material = mat[1];
		}
	}
}