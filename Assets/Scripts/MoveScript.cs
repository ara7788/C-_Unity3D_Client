using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class MoveScript : MonoBehaviour {
	public Transform StartPoint;
	public Transform EndPoint;
	public float Speed = 3;
	public GameObject MoneyPrefab;
	public GameObject BuyPlace;
	private int timeToMove = 0;
	private int payCount = 0;
	private bool isOnTheBuyPlace = false;
	private bool isOnStartPoint = false;
	private bool isTimeToGo = false;
	public Camera[] CameraPlay;
	public Text Bill;
	public int _payed = 0;


	// Use this for initialization
	void Start () {
		// Установка персонажа на стартовой позиции. Включение Главной камеры.
		transform.position = new Vector3 (StartPoint.position.x,StartPoint.position.y,StartPoint.position.z);
		CameraPlay [0].enabled = true;
		CameraPlay [1].enabled = false;
	}
	// Update is called once per frame
	void Update () {

		//Перемещение на позицию
		if (transform.position != EndPoint.transform.position && isOnTheBuyPlace == false) {
			transform.position = Vector3.MoveTowards (transform.position, EndPoint.transform.position, Time.deltaTime * Speed);
			GetComponent<Animator> ().SetBool ("walkBool", true);
		}
		//Передача купюр
		if (transform.position == EndPoint.transform.position && isOnTheBuyPlace == false) {
			isOnTheBuyPlace = true;
			CameraPlay [0].enabled = false;
			CameraPlay [1].enabled = true;
			GetComponent<Animator> ().SetBool ("walkBool", false);
		}
		//Возврат на старт
		if (transform.position == EndPoint.transform.position && isOnTheBuyPlace == true) {
			if (timeToMove == payCount && Input.GetMouseButtonDown (1)) {
				GetComponent<Animator> ().SetBool ("joyBool", true);
				CameraPlay [0].enabled = true;
				CameraPlay [1].enabled = false;
				_payed = 2;
			}
			if (timeToMove > payCount && Input.GetMouseButtonDown (1)) {
				GetComponent<Animator> ().SetBool ("sadBool", true);
				CameraPlay [0].enabled = true;
				CameraPlay [1].enabled = false;
				_payed = 1;
			}
			if (timeToMove < payCount && Input.GetMouseButtonDown (1)) {
				GetComponent<Animator> ().SetBool ("sadBool", true);
				CameraPlay [0].enabled = true;
				CameraPlay [1].enabled = false;
				_payed = 1;
			}
			if (Input.GetMouseButtonDown (2)) {
				GetComponent<Animator> ().SetBool ("joyBool", false);
				GetComponent<Animator> ().SetBool ("sadBool", false);
				GetComponent<Animator> ().SetBool ("walkBool", true);
				isTimeToGo = true;
			}
		}
		if (isTimeToGo == true) {
			transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);
			transform.position = Vector3.MoveTowards (transform.position, StartPoint.position, Time.deltaTime * Speed);
			isOnStartPoint = true;	
		}
		//Разворот на старте
		if (transform.position == StartPoint.transform.position && isOnStartPoint == true) {
			transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
			GetComponent<Animator> ().SetBool ("walkBool", false);
		}


		//Получение значений переменных Стоимость "ammocount" и Оплата "count" из скрипта PayScript
		timeToMove = Bill.gameObject.GetComponent<TextOutputScript> ().ammoValue;
		//Debug.Log ("Move_timeToMove: " + timeToMove);
		payCount = BuyPlace.gameObject.GetComponent<GameObjectDragAndDrop> ().countGo;
		//Debug.Log ("Move_payCount: " + payCount);




	}
}
