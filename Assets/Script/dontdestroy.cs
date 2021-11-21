using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroy : MonoBehaviour
{
	public static bool backPlay = false;

	// Start is called before the first frame update
	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	void OnGUI()
	{
		if (GUI.Button(new Rect(Screen.width - 50,0,50,30),"Music"))
		{
			backPlay = !backPlay;
			if (backPlay)
				GetComponent<AudioSource>().Play();
			else
				GetComponent<AudioSource>().Stop();
		}
	}
}
