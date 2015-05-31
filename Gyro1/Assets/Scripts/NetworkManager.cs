using UnityEngine;

public class NetworkManager : Photon.MonoBehaviour {
	private int flag ;
	public GameObject button1;
	public GameObject button2;
	public GameObject camera1;

	public void ChangeFlag1(){
				flag = 1;
		}
	public void ChangeFlag2(){
				flag = 2;
		}



	void Awake() {
		//データ送信レート
		PhotonNetwork.sendRate = 15;
		PhotonNetwork.sendRateOnSerialize = 15;
		//マスターサーバー（ロビーサーバー）へ接続
		PhotonNetwork.ConnectUsingSettings("v0.1");
	}
	
	void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
						flag = 2;
			Debug.Log("flag=2");

				}

		if(flag == 2 && GameObject.Find("Camera(Clone)") == null ){
			Vector3 spawnPosition = new Vector3 (0, 2, -1); //生成位置
			GameObject player = PhotonNetwork.Instantiate ("Camera", spawnPosition, Quaternion.identity, 0);
			Object.Destroy(camera1);
			//カメラのターゲットにプレイヤーを指定
			CameraController.target = player.transform;
			flag=0;
			Destroy(button1);
			Destroy(button2);
		}
		if (flag == 1) {
						Destroy (button1);
						Destroy (button2);
			GameObject player2 = GameObject.Find("PlayerPrefab(Clone)");
			if(player2 != null){
				CameraController.target = player2.transform;
				Debug.Log("player2 camera");
				flag=0;
			}
				}
	}

	//ロビー参加成功時のコールバック
	void OnJoinedLobby() {
		//ランダムへルームへ参加
		PhotonNetwork.JoinRandomRoom();
	}
	
	//ルーム参加失敗時のコールバック
	void OnPhotonRandomJoinFailed() {
		Debug.Log("ルームへの参加に失敗しました");
		//名前のないルームを作成
		PhotonNetwork.CreateRoom(null);
	}

	void OnGUI() {
		//サーバーとの接続状態をGUIへ表示
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());

	}

	//ルーム参加成功時のコールバック
	void OnJoinedRoom() {
		Debug.Log("ルームへの参加に成功しました");
		//プレイヤーをインスタンス化
			
	}


}