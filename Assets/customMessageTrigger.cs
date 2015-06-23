using UnityEngine;
using System.Collections;

public class customMessageTrigger : MonoBehaviour {


	public UIMessageScript script;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{

		if(other.gameObject.CompareTag("Player"))
		{
			script.setMessageNum(1);
		}
	}
}
