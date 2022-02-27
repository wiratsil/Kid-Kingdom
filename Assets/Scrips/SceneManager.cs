using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour 
{
	void Awake()
	{
		Remember ();
	}

	void OnApplicationQuit()
	{
		PlayerPrefs.DeleteKey ("CurrentLevel");
	}

	public static void Remember()
	{
		int currentLevel = Application.loadedLevel;
		PlayerPrefs.SetInt ("CurrentLevel", currentLevel); 
	}

	public static void Undo()
	{
		int currentLevel = PlayerPrefs.GetInt ("CurrentLevel", 0);
		Application.LoadLevel (currentLevel);
	}
}
