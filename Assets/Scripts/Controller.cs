using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	private Rigidbody rb;

	bool didfall;

	private int count;

	int destroyCounter = 0;

	public Text countText;
	public Text winText;
	public float downSpeed;

	float timeCounter = 0;
	public bool isFalling;

	void Start() {

		rb = GetComponent<Rigidbody>(); 
		count = 0;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("pickup")) {
			
			other.gameObject.SetActive (false);
			count = count + 1;
			if (count == 4) {
			}
		}
		if(other.gameObject.CompareTag ("platform")){
			didfall = true;
			//platformUpdate(other , didfall , timeCounter);

		}

	}
	/*
	void platformUpdate(Collider go , bool check , float timeCounter)
	{
		timeCounter += Time.deltaTime;
		if (check) {
			downSpeed += Time.deltaTime / 10;
			go.gameObject.transform.position = new Vector3 (go.transform.position.x,
				go.gameObject.transform.position.y - downSpeed, 
				go.gameObject.transform.position.z);

		}
		destroyCounter++;
	
		platformUpdate (go , check , timeCounter);

	}*/


}
