using UnityEngine;
using System.Collections;
using System.Linq;
using System;
using ini_hndl;

public class MaterialChanger : MonoBehaviour
{
	bool gfx_bump = false, gfx_par = false;
	bool snd_midi = false;
	bool gfx_grass = false, gfx_post = false;
	bool gfx_water = false, gfx_mirror = false;
	int gfx_postqual;
	float gfx_fov = 60.0f;
	float vol_mus;
	float mouse_sens = 5.0f;
	
	public GameObject maincam;
	public AudioClip altmusic;
	public GameObject mirrors;
	
	void Start()
	{
		IniHandler cfg = new IniHandler(ConfigLoader.filename);
		cfg.LoadIni();
		gfx_bump = cfg["Bump"] != "0";
		gfx_par = cfg["Par"] != "0";
		gfx_post = cfg["Post"] != "0";
		gfx_water = cfg["Water"] != "0";
		gfx_mirror = cfg["Mirror"] != "0";
		int.TryParse(cfg["PostQuality"], out gfx_postqual);
		if(gfx_postqual < 0) gfx_postqual = 0;
		else if(gfx_postqual > 2) gfx_postqual = 2;
		if(!float.TryParse(cfg["FOV"], out gfx_fov))
			gfx_fov = 60.0f;
		if(!float.TryParse(cfg["MVolume"], out vol_mus))
			vol_mus = 1.0f;
		if(!float.TryParse(cfg["MouseSens"], out mouse_sens))
			mouse_sens = 5.0f;
		gfx_grass = cfg["Grass"] != "0";
		snd_midi = cfg["MIDI"] != "0";
		//Bumpmap, Parallaxmap
		if(!gfx_bump)
			Shader.globalMaximumLOD = 200;
		else if(!gfx_par)
			Shader.globalMaximumLOD = 400;
		else
			Shader.globalMaximumLOD = int.MaxValue;
		//Grass
		if(!gfx_grass)
		{
			GrassStream vegs = GetComponent<GrassStream>();
			vegs.enabled = false;
			foreach(Transform t in vegs.objs)
				Destroy(t.gameObject);
			Destroy(vegs);
		}
		//Water
		if(gfx_water)
		{
			GetComponent<WaterRefl>().DisableReflWater();
		}
		//Mirrors
		if(!gfx_mirror)
		{
			GetComponent<StreamScript>().mirrors = new ZBound[0];
			Destroy(mirrors);
		}
		//Music volume
		maincam.audio.volume = vol_mus;
		if(vol_mus == 0)
		{
			GameBase.music_dis = true;
			maincam.audio.Stop();
		}
		else GameBase.music_dis = false;
		//MIDI
		if(!snd_midi) maincam.audio.clip = altmusic;
		GameBase.music_midi = snd_midi;
		maincam.audio.Play();
		//Post processing
		if(gfx_post)
		{
			maincam.GetComponent<SSAOEffect>().enabled = true;
			maincam.GetComponent<SSAOEffect>().m_SampleCount = (SSAOEffect.SSAOSamples)gfx_postqual;
			maincam.GetComponent<SunShafts>().enabled = true;
			maincam.GetComponent<SunShafts>().resolution = (SunShaftsResolution)gfx_postqual;
			maincam.GetComponentInChildren<BloomAndLensFlares>().enabled = true;
		}
		else
		{
			Destroy(maincam.GetComponent<SSAOEffect>());
			Destroy(maincam.GetComponent<SunShafts>());
			Destroy(maincam.GetComponent<Vignetting>());
			Destroy(maincam.GetComponentInChildren<BloomAndLensFlares>());
		}
		//FOV
		maincam.camera.fov = gfx_fov;
		//Mouse sensitivity
		MouseLook look = maincam.GetComponent<MouseLook>();
		look.sensitivityX = mouse_sens;
		look.sensitivityY = mouse_sens;
		Destroy(this);
	}
}