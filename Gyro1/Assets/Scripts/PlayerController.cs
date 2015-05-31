using UnityEngine;

public class PlayerController : Photon.MonoBehaviour {
	
	public float jumpPower = 300f;
	public float movePower = 10f;

	void Update () {
		if(photonView.isMine){
			//移動
			float inputX = Input.GetAxis("Horizontal");
			float inputY = Input.GetAxis("Vertical");
			Vector2 force = new Vector2(inputX, inputY) * movePower;
			GetComponent<Rigidbody2D>().AddForce(force);

			//ジャンプ
			if(Input.GetButtonDown("Jump")) {
				GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
			}
		}
	}
}
