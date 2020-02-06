using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
	public void ResetScene(string _sceneName)
	{
		SceneManager.LoadScene(_sceneName);
	}
}