using UnityEngine;
using System.Collections;

public class CrystalHalo : MonoBehaviour {

	public Light lightTop;
	public Light lightCenter;
	public Light lightBot;

	public float minGlow;
	public float maxGlow;


	private bool glowIncr;



	void Start () {
		lightCenter.intensity = 1.0f;
		glowIncr = true;
		if (maxGlow > 8.0f) {
			print ("ERROR MAXGLOW MUST BE LESS THAN OR EQUAL TO 8.0f");
		}
	}
	

	void Update () {
		if (glowIncr) {
			if(lightCenter.intensity < maxGlow){
				lightCenter.intensity+=0.1f;
			}
			else{
				glowIncr = false;

			}
		}
		else {
			if(lightCenter.intensity > minGlow){
				lightCenter.intensity-=0.1f;

			}
			else{
				glowIncr = true;

			}
		}
	}
}
