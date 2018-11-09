using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
    public GameObject Player;
    public GameObject Asteroid;
	public int scoreValue;
	private GameController gameController;
    
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}

		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			//gameController.GameOver();
            Destroy(Player);
		}
		if (other.tag == "Shot")
        {
            Destroy(Asteroid);
            Destroy(other.gameObject);
        }
		gameController.AddScore(scoreValue);

		Destroy (other.gameObject);
		Destroy (gameObject);

	}
}