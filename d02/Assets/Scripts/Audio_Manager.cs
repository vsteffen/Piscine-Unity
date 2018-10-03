using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour {
	public static Audio_Manager	instance { get; private set;}
	AudioSource source;

    bool m_Play;
    //Detect when you use the toggle, ensures music isn’t played multiple times
    bool m_ToggleChange;

	void Awake()
    {
		instance = this;
        //Fetch the AudioSource from the GameObject
        source = GetComponent<AudioSource>();
        //Ensure the toggle is set to true for the music to play at start-up
        // m_Play = true;
    }

	public void set_music(AudioClip to_play) {
		source.PlayOneShot(to_play);
	}

    void Update()
    {

    }

}
