using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {
	//変数
	NavMeshAgent agent;
	GameObject player ;
	public GameObject[] doors;
	public GameObject[] corners;

	Transform destination;
	//今向かっている対象
	Transform destinationNow;
	Transform destinationGoal;

	GameManager gameManager;


	public float speed = 5;
	public int doorDecider;
	public int cornerDecider;

	void Start () {
		//敵がplayerのオブジェクトを探すため名前で取得
		player = GameObject.Find ("Player");
		agent = GetComponent<NavMeshAgent>();
		destination = doors [0].transform;
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		doorDecider = 0;
		cornerDecider = 5;
		//敵スピードをフレームごとに揃えるには・・・？
		agent.speed = 5;
	}
	
	// Update is called once per frame
	void Update () {
		agent.SetDestination (destination.position);
	   
	} 


		/*if (Input.GetKeyDown ("1")) {
			destination = doors [0].transform;
		}
		if (Input.GetKeyDown ("2")) {
			destination = doors [1].transform;
		}
		if (Input.GetKeyDown ("3")) {
			destination = doors [2].transform;
		}
		if (Input.GetKeyDown ("4")) {
			destination = doors [3].transform;
		}
		if (Input.GetKeyDown ("5")) {
			destination = doors [4].transform;
		}
		if (Input.GetKeyDown ("p")) {
			destination = player.transform;
		}
*/


	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Door") {
			if(col.gameObject.GetComponent<DoorContorller>().id == 0){
				//ドアしまってたら
				if (gameManager.isDoorOpen [0] == false) {
					//コーナー２，３のどちらかを決める
					cornerDecider = Random.Range (0, 2);
					if (cornerDecider == 0) {
						SetDestinationTransform (corners [0].transform, "corners[0]");
					}
					if (cornerDecider == 1){
						SetDestinationTransform (corners [1].transform, "corner[1]");
					}
				} else {
					SetDestinationTransform (player.transform, "player");
				}
			}
			if (col.gameObject.GetComponent<DoorContorller> ().id == 1) {
				if (gameManager.isDoorOpen [1] == false) {
					cornerDecider = Random.Range (1, 3);
					if (cornerDecider == 1) {
						SetDestinationTransform (corners [1].transform, "corners[1]");
					}
					if (cornerDecider == 2) {
						SetDestinationTransform (corners [2].transform, "corners[2]");
					}
				} else {
					SetDestinationTransform (player.transform, "player");
				}
			}
			if(col.gameObject.GetComponent<DoorContorller>().id == 2){
				if (gameManager.isDoorOpen [2] == false) {
					cornerDecider = Random.Range (1, 3);
					if (cornerDecider == 1) {
						SetDestinationTransform (corners [1].transform, "corners[1]");
					}
					if (cornerDecider == 2) {
						SetDestinationTransform (corners [2].transform, "corners[2]");
					}
				} else {
					SetDestinationTransform (player.transform, "player");
				}
			} 
			if(col.gameObject.GetComponent<DoorContorller>().id == 3){
				if (gameManager.isDoorOpen [3] == false) {
					cornerDecider = Random.Range (2, 4);
					if (cornerDecider == 2) {
						SetDestinationTransform (corners [2].transform, "corners[2]");
					}
					if (cornerDecider == 3) {
						SetDestinationTransform (corners [3].transform, "corners[3]");
					}
				} else {
					SetDestinationTransform (player.transform, "player");
				}
			}
			if(col.gameObject.GetComponent<DoorContorller>().id == 4){
				if (gameManager.isDoorOpen [4] == false) {
					cornerDecider = 0;
					SetDestinationTransform (corners [0].transform, "corners[0]");
				} else {
					SetDestinationTransform (player.transform, "player");
				}
			} 
		}
		//Cornerに到達したときの処理
		if (col.gameObject.tag == "Corner") {
			if (col.gameObject.GetComponent<CornerController> ().cornerId == 0) {
				doorDecider = 0;
				SetDestinationTransform (doors [0].transform, "doors[0]");
			}
			if (col.gameObject.GetComponent<CornerController> ().cornerId == 1) {
				doorDecider = Random.Range (0, 2);
				if(doorDecider == 0){
					SetDestinationTransform (doors [0].transform, "doors[0]");
				}
				if(doorDecider == 1){
					SetDestinationTransform (doors [1].transform, "doors[1]");
				}
			}
			if (col.gameObject.GetComponent<CornerController> ().cornerId == 2) {
				doorDecider = Random.Range (2, 4);
				if(doorDecider == 2){
					SetDestinationTransform (doors [2].transform, "doors[2]");
				}
				if(doorDecider == 3){
					SetDestinationTransform (doors [3].transform, "doors[3]");
				}	
			}
			if (col.gameObject.GetComponent<CornerController> ().cornerId == 3) {
				doorDecider = Random.Range (3, 5);
				if(doorDecider == 3){
					SetDestinationTransform (doors [3].transform, "doors[3]");
				}
				if(doorDecider == 4){
					SetDestinationTransform (doors [4].transform, "doors[4]");
				}
			}
		}
		
		/*当たった0ドアをオープンにするコード
		gameManager.isDoorOpen [0] = true;
*/
	}

	void SetDestinationTransform(Transform targetTransform, string str){
		destination = targetTransform;
		Debug.Log ("Destination set to " + targetTransform.position + ".(" + str + ")");
	}

}
