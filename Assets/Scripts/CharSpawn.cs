using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharSpawn : MonoBehaviour {

	public Transform spawn ;
	protected float cooldown ;
	public int mp ;
	public Button[] summon;
	public Player player;


	public void shot (Character soilder) {

//			if (cooldown >= 1.5f && player.mana >= mp) 
//			{ 
//
//				Character clone = Instantiate (soilder, spawn.position, spawn.rotation) as Character;
//			clone.tag = "Player";
//				clone.isPlayer = true;
//				cooldown = -2.0f;
//				player.mana -= mp;
//
//
//			}
		#region test

			if (player.mana >= mp) { 
			
				Character clone = Instantiate (soilder, spawn.position, spawn.rotation) as Character;
				clone.tag = "Player";
				clone.isPlayer = true;
				player.mana -= mp;

		}
			#endregion

	
	}



	void Update () {
		Cd0 ();
		Cd1 ();
		Cd2 ();
		Cd3 ();
		Cd4 ();
	



		
	}
	
	void Cd0 () {
	
			if(summon[0].image.fillAmount < 1)
			{
				summon[0].image.fillAmount += 0.008f;
			}
			else
			{
				summon[0].interactable = true ;
			}

			if(player.mana < mp)
			{
				summon[0].interactable = false ;
			}
		

	}
	void Cd1 () {
		
		if(summon[1].image.fillAmount < 1)
		{
			summon[1].image.fillAmount += 0.005f;
		}
		else
		{
			summon[1].interactable = true ;
		}
		
		if(player.mana < mp)
		{
			summon[1].interactable = false ;
		}
		
		
	}
	void Cd2 () {
		
		if(summon[2].image.fillAmount < 1)
		{
			summon[2].image.fillAmount += 0.003f;
		}
		else
		{
			summon[2].interactable = true ;
		}
		
		if(player.mana < mp)
		{
			summon[2].interactable = false ;
		}
		
		
	}
	void Cd3 () {
		
		if(summon[3].image.fillAmount < 1)
		{
			summon[3].image.fillAmount += 0.001f;
		}
		else
		{
			summon[3].interactable = true ;
		}
		
		if(player.mana < mp)
		{
			summon[3].interactable = false ;
		}
		
		
	}
	void Cd4 () {
		
		if(summon[4].image.fillAmount < 1)
		{
			summon[4].image.fillAmount += 0.0008f;
		}
		else
		{
			summon[4].interactable = true ;
		}
		
		if(player.mana < mp)
		{
			summon[4].interactable = false ;
		}
		
		
	}

	public void v (int y)
	{
		summon[y].image.fillAmount = 0 ;
		summon[y].interactable = false ;

	}






}
