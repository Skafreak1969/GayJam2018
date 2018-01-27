using UnityEngine;
using System.Collections;

public class CamerSmooth : MonoBehaviour {
	private Vector2 velocity;

	public float smoothTimey;
	public float smoothTimex;

	public GameObject player;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void LateUpdate()
	{
		float posx = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimex);
		float posy = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimey);

		transform.position = new Vector3 (posx, posy, transform.position.z);
	}
}
