using UnityEngine;
using System.Collections.Generic;

public class Character : MonoBehaviour 
{
	public const float MIN_ATTACK_SPEED = 0f; // time per sec
	public const float MAX_ATTACK_SPEED = 5f;

	// Move
	// Attack : One - One, One - Many (Range included)

	public enum State
	{
		Move, Attack
	}

	private State state;

	public int hp ;
	public int damage;
	public float speed;
	public float range;
	public int level;
	public float dieCooldown;


	protected Animator ani;

	[Range(MIN_ATTACK_SPEED, MAX_ATTACK_SPEED)]
	public float attackSpeed = MIN_ATTACK_SPEED;

	public bool areaOfAttack;
	public bool isPlayer;

	protected Rigidbody rigi;

	private List<Character> enemies;
	private string enemyTag;

	protected virtual void Awake()
	{
		rigi = GetComponent<Rigidbody> ();
		state = State.Move;

		ani = GetComponent<Animator> ();

	}

	// Use this for initialization
	protected virtual void Start ()
	{


		if(!isPlayer)
			speed = -speed;
	

		MoveForward ();
		
		enemyTag = (tag == "Player") ? "Enemy" : "Player";
	}

	protected void MoveForward ()
	{
		ani.SetBool ("hit", false);
		rigi.velocity = transform.right*speed;
		
	}

	protected virtual void Update()
	{
		switch(state)
		{
			case State.Move : OnMove(); break;
			case State.Attack : OnAttack(); break;
		}
	}


	protected void OnMove()
	{
		enemies = QueryEnemies ();

		if(enemies.Count > 0)
		{

			state = State.Attack;
			StartCoroutine(OnAttacking());

			rigi.velocity = Vector3.zero;

		}
	}

	protected void OnAttack()
	{
		enemies = QueryEnemies ();

		if(enemies.Count == 0)
		{
		
			state = State.Move;

			StopAllCoroutines();
			MoveForward ();
		}
	}

	protected System.Collections.IEnumerator OnAttacking()
	{
		ani.SetBool ("hit", true);

		float delay = 1f / attackSpeed;

		while(enemies.Count > 0)
		{

			try
			{
				if(areaOfAttack)
				{


					print ("Attack Group : " + enemyTag);

					for(int i = 0; i < enemies.Count;)
					{
						Character enemy = enemies[i];
						enemy.hp -= damage;

						if(enemy.hp <= 0)
						{
							enemies.RemoveAt(i);
							enemy.DieEnter();

							continue;
						}

						i++;
					}

				}
				else
				{


					print ("Attack : " + enemyTag);

					Character enemy = FindNearestEnemy();
					enemy.hp -= damage;


					
					if(enemy.hp <= 0)
					{
						enemies.Remove(enemy);
						enemy.DieEnter();
					}
				}
			}
			catch(MissingReferenceException)
			{
				print ("Null Ref");
			}

			yield return new WaitForSeconds(delay);
		}

		MoveForward ();
		state = State.Move;
	}

	protected Character FindNearestEnemy()
	{
		float minValue = float.MaxValue;
		Character nearest = null;

		Vector3 p1 = transform.position;
		foreach(Character c in enemies)
		{
			Vector3 p2 = c.transform.position;
			float distance = Vector3.Distance(p1, p2);

			if(distance < minValue)
			{
				nearest = c;
				minValue = distance;
			}
		}

		return nearest;
	}

	protected virtual void OnCollisionEnter(Collision other)
	{
		rigi.Sleep ();
	}

	protected List<Character> QueryEnemies()
	{
		Vector3 position = transform.position;
		Collider[] cs = Physics.OverlapSphere (position, range);

		List<Character> enemies = new List<Character> ();
		foreach(Collider c in cs)
		{
			if(!c.CompareTag(enemyTag))
				continue;

			Character character = c.GetComponent<Character>();
			enemies.Add(character);
		}

		return enemies;
	}

	private void DieEnter()
	{

		ani.SetBool ("die", true);
		Invoke ("DieExit", dieCooldown);
	}

	protected virtual void DieExit()
	{
		DestroyObject (gameObject);
	}























	
	// Update is called once per frame
//	void Update () {
//		FindTarget ();
//	}

//	protected virtual void OnCollisionStay(Collision other)
//	{
//
//	}
//
//	protected virtual void OnCollisionExit(Collision other)
//	{
//		MoveForward ();
//	}

//	void FindTarget(){
//		if (this.tag == "Player") {
//			Character enemys[] = GameObject.FindGameObjectsWithTag("Enemy") as Character;
//			foreach(Character clone in ememys){
//				//clone.transform.position < attack range;
//			}
//			 
//		} else {
//			GameObject.FindGameObjectsWithTag("Player");
//		}
//	}
}
