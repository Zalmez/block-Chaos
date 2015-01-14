using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	public Text scoreText;
	private int score = 0;
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		scoreText.text = score.ToString();
	}
	
	void OnLevelWasLoaded (int levelIndex) {
		if (Application.loadedLevelName == "_Start Menu") {
			print ("Destroying " + gameObject);
			Destroy (gameObject);
		}
	}
	
	public void Add (int amount) {
		score += amount;
		// We update here rather than in Update
		// That way we only call when needed not every frame
		scoreText.text = score.ToString();
	}
	
	public int GetScore () {
		// We're doing this to be good
		return score;
	}
}
