using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int count;

	void Start() {
		count = 0;
		SetCountText();
		winText.text = "";
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce(movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive (false);
			count += 1;
			SetCountText ();
		} else if (other.gameObject.tag == "Death Zone") {
			EndGame();
		}
	}

	void SetCountText() {
		countText.text = "Count: " + count.ToString();
		if (count >= 12) {
			winText.text = "YOU WIN!";
		}
	}

	void EndGame() {
		winText.text = "YOU LOST!";
		StartCoroutine (Pause (3));
	}

	private IEnumerator Pause(int p)
	{
		Time.timeScale = 0.0001f;
		float pauseEndTime = Time.realtimeSinceStartup + 1;
		while (Time.realtimeSinceStartup < pauseEndTime)
		{
			yield return 0;
		}
		Time.timeScale = 1;
		Application.LoadLevel (Application.loadedLevel);
	}
}
