using UnityEngine;

public class Synchronizer_at_Camera : Photon.MonoBehaviour {
	//受信したデータ
	public static Vector3 receivePosition = Vector3.zero;
	public static Quaternion receiveRotation = Quaternion.identity;
	public static Vector2 receiveVelocity = Vector2.zero;
	public static int receiveViewID ;

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		if (stream.isWriting) {
			//データの送信
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
			stream.SendNext(GetComponent<Rigidbody2D>().velocity);
			stream.SendNext(GetComponent<PhotonView>().viewID);
			Debug.Log("自分のID(Syncronizer):" + GetComponent<PhotonView>().viewID );
		} else {
			//データの受信（変数へ格納）
			receivePosition = (Vector3)stream.ReceiveNext();
			receiveRotation = (Quaternion)stream.ReceiveNext();
			receiveVelocity = (Vector2)stream.ReceiveNext();
		//	receiveViewID = (int)stream.ReceiveNext();
		//	Debug.Log("相手のID:"+ (int)stream.ReceiveNext());
			Debug.Log("相手のいち情報(Sync_at_camera)："+receivePosition);
		}
	}
	

}