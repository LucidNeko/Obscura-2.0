using UnityEngine;
using System.Collections;

public class BigCrystal2222 : MonoBehaviour {

	public GameObject island;
	public Transform destination;

//	public GameObject crysM;
	private CrystalPickup cp;

	public UIMessageScript ms;

	private bool canMoveTheIsland = true;


	// Use this for initialization
//	void Start () {
//		cp = crysM.GetComponent<CrystalPickup> ();
//	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals ("Player")) {
			int quantity = CrystalPickup.crystalsCollected;// cp.GetCrystalsCollected();
			Debug.Log(CrystalPickup.crystalsCollected);
			if(quantity < 5){
				ms.setMessageNum(0);
			}
			else{
				ms.setMessageNum(1);
				if(canMoveTheIsland) {
					canMoveTheIsland = false;
					//GameObject.FindGameObjectWithTag("Player").transform.SetParent(island.transform);
					StartCoroutine(EnoughCrystals());
					Camera.main.GetComponent<CameraControls>().LookAt(destination.position, 9, 10);
				}
			}
		}
	}

	public IEnumerator EnoughCrystals(){
		CrystalPickup.crystalsCollected -= 5;

		float speed = 0.1f;
		float time = 0;

		Vector3 start = island.transform.position;
		Vector3 end = destination.position;

		Vector3 diff = end - start;

		Vector3 startIsland = island.transform.position;

		do {
			island.transform.position = Vector3.Lerp(startIsland, startIsland + diff, time);
			yield return null;
		} while((time += speed * Time.deltaTime) < 1);

		Camera.main.GetComponent<CameraControls> ().Shake(0.3f,1f);

		island.transform.position = startIsland + diff;

//		canMoveTheIsland = true;

		//GameObject.FindGameObjectWithTag("Player").transform.SetParent(null);
	}



}
