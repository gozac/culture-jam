using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
	public GameObject helpmenu;

	public GameObject lienmenu;

	public GameObject creditmenu;

	public void Play() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Help() {
		Debug.Log("Help");
		helpmenu.SetActive(true);
		this.gameObject.SetActive(false);
	}

	public void Lien() {
		Debug.Log("Lien");
		lienmenu.SetActive(true);
		this.gameObject.SetActive(false);
	}

	public void Credit() {
		Debug.Log("Credit");
		creditmenu.SetActive(true);
		lienmenu.gameObject.SetActive(false);
	}

	public void Back() {
		Debug.Log("Back");
		helpmenu.SetActive(false);
		lienmenu.SetActive(false);
		creditmenu.SetActive(false);
		this.gameObject.SetActive(true);
	}


	public void WebAccess() {
		Application.OpenURL("https://www.webaccess.ci");
	}

	public void Gomycode() {
		Application.OpenURL("https://gomycode.com/CI-FR/home");
	}

	public void Bushman() {
		Application.OpenURL("https://www.instagram.com/bushman.cafe");
	}

		public void Musee() {
		Application.OpenURL("https://www.museedescivilisations.com");
	}


	public void Quit() {
		Debug.Log("End");
		Application.Quit();
	}
}
