using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class textFadeMove : MonoBehaviour
{
	public TextMeshProUGUI[] textes;

	int c = 0;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(FadeTextToFullAlpha(1f, textes[c]));
    }

    void Update() {
    	if (c >= textes.Length)
    		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void OnGUI()
    {
    	if (GUI.Button(new Rect(Screen.width - 110, Screen.height - 60, 100, 50), "Suivant")) {
    		StartCoroutine(FadeTextToZeroAlpha(1f, textes[c]));
    		c++;
    		StartCoroutine(FadeTextToFullAlpha(1f, textes[c]));
    	}
    }


    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }


    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
