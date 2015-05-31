using UnityEngine;

public class Synchronizer : Photon.MonoBehaviour {
	//受信したデータ
	private Vector3 receivePosition = Vector3.zero;
	private Quaternion receiveRotation = Quaternion.identity;
	private Vector2 receiveVelocity = Vector2.zero;
	private int receiveViewID ;

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) {
			//データの送信
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
			stream.SendNext(GetComponent<Rigidbody2D>().velocity);
			stream.SendNext(GetComponent<PhotonView>().viewID);
			Debug.Log("自分のID(viewID):" + GetComponent<PhotonView>().viewID );
		} else {
			//データの受信（変数へ格納）
			receivePosition = (Vector3)stream.ReceiveNext();
			receiveRotation = (Quaternion)stream.ReceiveNext();
			receiveVelocity = (Vector2)stream.ReceiveNext();
		//	receiveViewID = (int)stream.ReceiveNext();
		//	Debug.Log("相手のID:"+ (int)stream.ReceiveNext());
			Debug.Log("相手の位置情報(sync)" + receivePosition);
		}
	}
	
	void Update() {
		//自分以外のプレイヤーの補正
		if(!photonView.isMine){
			transform.position = Vector3.Lerp(transform.position, receivePosition, Time.deltaTime * 2);
			transform.rotation = Quaternion.Lerp(transform.rotation, receiveRotation, Time.deltaTime * 2);
			//Debug.Log(transform.position);
			GetComponent<Rigidbody2D>().velocity = Vector2.Lerp(GetComponent<Rigidbody2D>().velocity, receiveVelocity, Time.deltaTime * 2);

		}
	}
}