using UnityEngine;

public class LevelInformation : MonoBehaviour {

    public AudioClip sceneMusic;

	// Use this for initialization
	void Start ()
    {
        AudioManager.instance.CurrentClip = sceneMusic;		
	}
}
