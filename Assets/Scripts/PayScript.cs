using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PayScript : MonoBehaviour {
	
	public GameObject MoneyPrefab;
	GameObject money;
	private float i=0.0f;

	// Use this for initialization
	void Start () {
		for (i =0.0f; i< 5.0f; i++){
			money = Instantiate (MoneyPrefab, new Vector3(-1.36f, 10.0f + i, 1.0f), Quaternion.identity ) as GameObject;
			money.transform.rotation = Quaternion.Euler(0, 0, 180);
		//	Debug.Log (i);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
