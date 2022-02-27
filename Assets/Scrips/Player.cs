using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
//	protected string name;
	protected int cash;
	protected int bottle;
	public float mana;
	public float Upgrade ;
	public Slider mana_bar;
	public Text mana_text;
	int mtext ;

	// Use this for initialization
	void Start () {
		mana_bar.maxValue = 100;
		mana_bar.value = 0;

	
	
	}
	
	// Update is called once per frame
	void Update () {
	
		MP ();
	}
	public void MP () {
		
		mana += 0.02f * Upgrade;
		if (mana > 100.0f)
			mana = 100.0f;
		mana_bar.value = mana;
		mtext = (int)mana;
		mana_text.text = mtext.ToString();
	}
}
