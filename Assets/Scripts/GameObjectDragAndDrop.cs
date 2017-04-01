using UnityEngine;
using System.Collections;

//Детект объекта, при клике по этому объекту
public class GameObjectDragAndDrop : MonoBehaviour {
	private bool isMouseDrag;
	Vector3 screenPosition;
	GameObject target = null;	
	Vector3	 offset;

	public int countGo = 0;


	GameObject ReturnClickedObject(out RaycastHit hit){
			
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray.origin, ray.direction * 10, out hit)){
			target = hit.collider.gameObject;
		}
		return target;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hitInfo;
			target = ReturnClickedObject (out hitInfo);
			if (target !=null) {
				isMouseDrag = true;
				//Debug.Log ("target position :" + target.transform.position);
				screenPosition = Camera.main.WorldToScreenPoint (target.transform.position);
				offset = target.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));

			}
		}
		if (Input.GetMouseButtonUp (0)) {
			isMouseDrag = false;
			countGo++;
			//Debug.Log ("GO_count :"+countGo);
		}
		if (isMouseDrag) {
			Vector3 currentScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
			Vector3 currentPosition = Camera.main.ScreenToWorldPoint (currentScreenSpace) + offset;
			target.transform.position = currentPosition;
		}
	}


}
