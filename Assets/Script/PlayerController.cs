using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	//速度変数
	public float speed = 5;
	public float rotation = 90;
	GameManager gameManager;


	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {


		//キー操作（進む、下がる）
	
		if(Input.GetKey("up") == true){
			this.transform.position += this.transform.forward * speed * Time.deltaTime;
		}
		if(Input.GetKey("down") == true){
			this.transform.position -= this.transform.forward * speed * Time.deltaTime;
		}

		//左右旋回
		if(Input.GetKey("right") == true){
			this.transform.Rotate (new Vector3 (0,rotation * Time.deltaTime, 0));
		}
		if(Input.GetKey("left") == true){
			this.transform.Rotate (new Vector3 (0, -rotation * Time.deltaTime, 0));
		}

	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Door") {
			if (col.gameObject.GetComponent<DoorContorller> ().id == 0) {
				gameManager.isDoorOpen [0] = false;
			}
			if (col.gameObject.GetComponent<DoorContorller> ().id == 1) {
				gameManager.isDoorOpen [1] = false;
			}
			if (col.gameObject.GetComponent<DoorContorller> ().id == 2) {
				gameManager.isDoorOpen [2] = false;
			}
			if (col.gameObject.GetComponent<DoorContorller> ().id == 3) {
				gameManager.isDoorOpen [3] = false;
			}
			if (col.gameObject.GetComponent<DoorContorller> ().id == 4) {
				gameManager.isDoorOpen [4] = false;
			}
		}

	}

}
