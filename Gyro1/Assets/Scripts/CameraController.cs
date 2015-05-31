using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public static Transform target;
	//Vector3 newposition2;
	GameObject Camera; 
	
	void Update () {
	//	newposition2 = Synchronizer_at_Camera.receivePosition;
	//	Debug.Log ("相手の位置情報(cameracontroller)：" + newposition2);
		Camera = GameObject.Find("Camera(Clone)"); 
		Debug.Log ("あいてのじょうほう：" + Camera.transform.position);
		Transform PP_position = Camera.transform;

		if (target) {
						//ターゲットを追従
						Vector3 newPosition = new Vector3 (transform.position.x, target.position.y, transform.position.z);
						transform.position = newPosition;
				} else {
						//transform.position = new Vector3(newposition2.x-2f, newposition2.y-2f,  newposition2.z-2f);
						transform.position = new Vector3 (PP_position.position.x - 0.5f, PP_position.position.y - 1.0f, PP_position.position.z - 0.5f);
				}
	}
}
