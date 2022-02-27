using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {
	private string levelpass;
	public int LoadSc;
	public bool IsLoad;
	
	public GameObject loadingImage;
	
	public void LoadScene(string level)
	{

		if (IsLoad) 
		{
			if(LoadSc == 0)
			{
				loadingImage.SetActive (false);
				Invoke ("Sc", LoadSc);
				levelpass = "" + level;
			}
				                     
			else


			{loadingImage.SetActive (true);
			Invoke ("Sc", LoadSc);
			levelpass = "" + level;
			}
		}
		else 
		{
			levelpass = "" + level;
			Sc();
		}



	}

	public void Undo()
	{
		loadingImage.SetActive (true);
		SceneManager.Undo ();
	} 

	protected virtual void Sc()
	{
	
		Application.LoadLevel(levelpass);
	}


}