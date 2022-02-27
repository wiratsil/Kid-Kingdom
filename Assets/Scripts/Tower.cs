using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tower : Character {

	public Slider hp_bar;



	// Use this for initialization
	void Start () {
		hp_bar.maxValue = hp;
		hp_bar.value = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		HPTower ();

	}


	protected override void DieExit(){
		// code player
		if (isPlayer) {
			LoadSceneLose();
		} else {
			LoadSceneWin();
		}
		base.DieExit ();
	}

	public void LoadSceneWin()
	{

		Application.LoadLevel("Youwin");
	}
	public void LoadSceneLose()
	{
		//loadingImage.SetActive(true);
		Application.LoadLevel("Youlose");
	}

	public void HPTower()
	{
		hp_bar.value = hp;

	}
}
