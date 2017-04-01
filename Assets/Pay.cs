using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	public GameObject MoneyPrefab;
	public Transform SellPlace;
	public float Speed = 1;
	GameObject money;

	// Use this for initialization
	void Start () {
		if(Input.GetMouseButtonDown(0)) {
			//money = Instantiate (Resources.Load<GameObject>("MoneyPrefab"),transform.position,Quaternion.identity) as GameObject;
			//money = Instantiate (MoneyPrefab, transform.position, transform.rotation) as GameObject;
			Debug.Log(SellPlace.name);
			Debug.Log(MoneyPrefab.name);
			Debug.Log(gameObject.name);
		}
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(1)){
			Debug.Log(MoneyPrefab.name);
			//money.transform.position = Vector3.MoveTowards (transform.position, SellPlace.position, Time.deltaTime*Speed);
		}
	}
}
