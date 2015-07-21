using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class microphone : MonoBehaviour {

	public float vol = 0;
	public float[] spectrum;
	public float max = 1;
	public float min = 1;


	private float GetAveragedVolume()
	{ 
		float[] data = new float[256];
		float a = 0;
		GetComponent<AudioSource>().GetOutputData(data,0);
		
		foreach(float s in data)
		{
			a += Mathf.Abs(s);
		}
		
		return a / 256;
	}

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().clip = Microphone.Start(null, true, 999, 44100);  // マイクからのAudio-InをAudioSourceに流す
		GetComponent<AudioSource>().loop = true;                                      // ループ再生にしておく
		GetComponent<AudioSource>().mute = true;                                      // マイクからの入力音なので音を流す必要がない
		while (!(Microphone.GetPosition("") > 0)){}             // マイクが取れるまで待つ。空文字でデフォルトのマイクを探してくれる
		GetComponent<AudioSource>().Play(); 

		spectrum = new float[1024];
	}

	// Update is called once per frame
	void Update () {
		spectrum = GetComponent<AudioSource>().GetSpectrumData(1024, 0, FFTWindow.BlackmanHarris);
		vol = GetAveragedVolume();

		if(vol > max){
			max = vol;
		}
		if(vol < min){
			min = vol;
		}

	}
}
