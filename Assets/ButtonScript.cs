using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	public GameObject m_Piller;

	private Animator m_Animator;

	public GameObject m_Crystal;

	// Use this for initialization
	void Start () {
		m_Animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			m_Animator.SetTrigger("Activate");
			Camera.main.GetComponent<CameraControls>().LookAt(m_Piller.transform.position, 3f, 4f);
//			StartCoroutine(DropCrystal());
			m_Piller.GetComponent<Animator>().SetTrigger("Activate");
		}
	}


//	public IEnumerator DropCrystal(){
//		float speed = 0.29f;
//		float time = 0;
//		Vector3 start = m_Crystal.transform.position;
//		Vector3 end = m_Crystal.transform.position + Vector3.down * 8.8f;
//		do{
//			m_Crystal.transform.position = Vector3.Lerp(start, end,time);
//			yield return null;
//		} while((time += speed * Time.deltaTime) < 1);
//	}

}
