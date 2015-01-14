using UnityEngine;
using System.Collections;

public class ZombieBehaviour : MonoBehaviour {
	public float health = 100f;
	public float damageDealt = 10f;
	
	private PlantBehaviour currentTarget;
	private ScoreKeeper myScoreKeeper;
	
	// Use this for initialization
	void Start () {
		this.rigidbody2D.velocity = new Vector2(-1, 0);
		myScoreKeeper = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		PlantBehaviour plantHit = collision.gameObject.GetComponent<PlantBehaviour>();
		
		if (plantHit) {
			currentTarget = plantHit;
			InvokeRepeating("Chomp", 1f, 1f);
			print ("Invoking repeat damage");
		}
		
	}	
	
	public void Chomp () {
		if (currentTarget) {
			currentTarget.Damage(damageDealt);
			audio.Play ();
			print ("Chomping plant");
		} else {
			this.rigidbody2D.velocity = new Vector2(-1, 0);
		}
	}
	
	public void Damage (float amount) {
		health = health - amount;
		
		if (health <= 0) {
			Destroy(gameObject);
			myScoreKeeper.Add(100);
		}
	}
}
