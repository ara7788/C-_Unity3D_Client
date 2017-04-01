using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextOutputScript : MonoBehaviour {

	public GameObject George;
	public Text ammo;
	public int ammoValue = 0;
	public int num = 0;
	private string emotions = ":-)";
	private string emotions2 = ":-(";
	private int payedText = 0;
	/// 


	// Use this for initialization
	void Start () {
		//Задание Суммы Random от 1 до 9
		num = Random.Range (1, 4);
		ammoValue = num;

	}
	
	// Update is called once per frame
	void Update () {

		//Вывод на экран Суммы и эмоций 
		payedText = George.gameObject.GetComponent<MoveScript> ()._payed;
		switch (payedText) {
		case 0:
			ammo.text = ammoValue.ToString();
			break;
		case 1:
			ammo.text = emotions2;
			break;
		case 2:
			ammo.text = emotions;
			break;
		default :
			ammo.text = ammoValue.ToString();
			//Debug.Log ("Tex_ammoValue = " + ammoValue);
			break;
		}
	}
}
