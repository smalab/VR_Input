//30行目のif文でうなずきを検知して選択できるようにする予定
//iPhoneを下に振るとyの加速度が下がる -1.15を下回ることでうなずき検知(yの加速度はニュートラルでも-0.9 ~ -1.0程ある)

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class jayro : MonoBehaviour {
	public GameObject[] targetObject = new GameObject[2];

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("X軸の加速度: " + Input.acceleration.x);
		Debug.Log ("Y軸の加速度: " + Input.acceleration.y);
		Debug.Log ("Z軸の加速度: " + Input.acceleration.z);

		//if(Input.acceleration.x < 0.1 && Input.acceleration.x > -0.1){ Debug.Log("X軸に近い");}
		//if(Input.acceleration.y < 0.1 && Input.acceleration.y > -0.1){Debug.Log("Y軸に近い");}
		//if(Input.acceleration.z < 0.1 && Input.acceleration.z > -0.1){Debug.Log("Z軸に近い");}
		
		if(Input.acceleration.x > 0.2){
			transform.position = targetObject[0].transform.position;
		}else if(Input.acceleration.x < -0.2){
			transform.position = targetObject[1].transform.position;
		}
		if(Input.acceleration.y < - 1.15 ){
			GetComponent<Image>().color = Color.red;
		}
		//自身の色を変更するif文
	}
}
