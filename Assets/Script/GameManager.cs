using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	//Door開閉管理
	public bool[] isDoorOpen = new bool[5];

	void Start () {
		isDoorOpen [0] = false;
		isDoorOpen [1] = false;
		isDoorOpen [2] = true;
		isDoorOpen [3] = false;
		isDoorOpen [4] = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
