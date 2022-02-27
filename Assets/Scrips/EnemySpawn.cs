using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour {
	public Transform SpawnE;
	public Character SaberE,ArcherE,LancerE,CasterE,BerserkerE;

	//public bool isBornSaber,isBornArcher,isBornLancer,isBornCaster,isBornBerserker;
	//public float SaberBorn,ArcherBorn,LancerBorn,CasterBorn,BerserkerBorn;
	//public float SaberReborn,ArcherReborn,LancerReborn,CasterReborn,BerserkerReborn;
	
	public bool isBornSaber;
	public float SaberBorn;
	public float SaberReborn;

	public bool isBornArcher;
	public float ArcherBorn;
	public float ArcherReborn;

	public bool isBornLancer;
	public float LancerBorn;
	public float LancerReborn;

	public bool isBornCaster;
	public float CasterBorn;
	public float CasterReborn;

	public bool isBornBerserker;
	public float BerserkerBorn;
	public float BerserkerReborn;

	

	void Start () 
	{
		if (isBornSaber) {
			InvokeRepeating ("Saber", SaberBorn, SaberReborn);
		}
		if (isBornArcher) {
			InvokeRepeating ("Archer", ArcherBorn, ArcherReborn);
		}
		if (isBornLancer) {
			InvokeRepeating ("Lancer", LancerBorn, LancerReborn);
		}
		if (isBornCaster) {
			InvokeRepeating ("Caster", CasterBorn, CasterReborn);
		}
		if (isBornBerserker) {
			InvokeRepeating ("Berserker", BerserkerBorn, BerserkerReborn);
		}
	}
	void Update () {
	
	
	
	}

	void Saber () {
	
		
		Character clone = Instantiate (SaberE, SpawnE.position, SpawnE.rotation) as Character;
		clone.isPlayer = false;
		clone.tag = "Enemy";
	
	}
	void Archer (){

			
		Character clone = Instantiate (ArcherE, SpawnE.position, SpawnE.rotation) as Character;
		clone.isPlayer = false;
		clone.tag = "Enemy";


	}
	void Lancer () {
			
		Character clone = Instantiate (LancerE, SpawnE.position, SpawnE.rotation) as Character;
		clone.isPlayer = false;
		clone.tag = "Enemy";
	
	}
	void Caster () {
			
		Character clone = Instantiate (CasterE, SpawnE.position, SpawnE.rotation) as Character;
		clone.isPlayer = false;
		clone.tag = "Enemy";
	

	}
	void Berserker () {
			
			Character clone = Instantiate (BerserkerE, SpawnE.position, SpawnE.rotation) as Character;
			clone.isPlayer = false;
			clone.tag = "Enemy";


	
	}

}
