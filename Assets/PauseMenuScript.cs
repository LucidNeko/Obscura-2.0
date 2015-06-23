using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

	public Camera cam;
	public GameObject canvas;

	Animator anim;
	bool paused = false;
	bool main = false;
	bool quit = false;

	void Start(){
		anim = canvas.GetComponent<Animator> ();
	}
		
	void Update()
	{
		if(Input.GetButtonDown("escape"))
			togglePause();
	}
		
		
	public void togglePause(){

		if(paused)
		{
			anim.SetBool("showPauseMenu", false);
			cam.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().enabled = false;
			Time.timeScale = 1f;
			paused = false;
		}



		else
		{
			cam.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().enabled = true;

			anim.SetBool("showPauseMenu", true);
			Time.timeScale = 0f;
			paused = true;    
		}
	}


	public void showmainMenuOption(bool set){
		main = set;
		anim.SetBool("showMenuOption", set);
	}


	public void showQuitOption(bool set){
		quit = set;
		anim.SetBool("showQuitOption", set);
	}

	public void yes(){
		if(quit){
			Debug.Log("Quit");
			Application.Quit();
		}

		if(main){
			Debug.Log("Main");
			//Application.LoadLevel("Main");
		}
	}


}
