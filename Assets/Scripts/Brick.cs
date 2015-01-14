using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip crack;
	public Sprite[] hitSprites;
	private bool isBreakable;
	public static int breakableCount = 0;
	public GameObject Smoke;
	public int Points = 100;
	
	private int ScorePoints = 0;
	private int OldScore = 0;
	
			
	private int timesHit;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
	isBreakable = (this.tag == "Breakable");
	//keep track of breakable brikcs
		if (isBreakable){
		breakableCount++;
	}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
}
	
	// Update is called once per frame
	void Update () {
		print (timesHit);
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		AddpointsScore();
		print(OldScore);
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable){
		handleHits();
		}
	}
	
	void handleHits () {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits){
			breakableCount--;
			levelManager.BrickDestroyed();
			GameObject smokePuff  = Instantiate(Smoke, transform.position, Quaternion.identity) as GameObject;
			smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
			Destroy(gameObject);
		} else {
			LoadSprites();
	}
}

	public void AddpointsScore(){
		ScoreCount();
	}
	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex] != null){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	
	public void ScoreCount(){
		ScorePoints++;
	}
	
}
