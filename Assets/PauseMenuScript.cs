using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

	public Camera cam; // The main view camera
	public GameObject canvas; // The pause menu canvas

	Animator anim; // The Animation controller for the canvas

	bool paused = false;
	bool main = false;
	bool quit = false;

	void Start(){
		anim = canvas.GetComponent<Animator> ();
	}
		
	void Update()
	{
		if(Input.GetButtonDown("Start"))
			togglePause();
	}
		
		
	// Handles display of the pause menu and stops all action in the scene
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


	// Hides and shows the Main Menu option
	public void showmainMenuOption(bool set){
		main = set;
		anim.SetBool("showMenuOption", set);
	}


	// Hides and shows the Quit option
	public void showQuitOption(bool set){
		quit = set;
		anim.SetBool("showQuitOption", set);
	}


	// Handles a yes press if main or quit selected
	public void yes(){
		if(quit){
			Application.Quit();
		}

		if(main){
			Time.timeScale = 1f;
			Application.LoadLevel(0);
		}
	}


}
