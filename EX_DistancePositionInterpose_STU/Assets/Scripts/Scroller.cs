using UnityEngine;
using Steerings;

public class Scroller : MonoBehaviour {

	public GameObject target;
	private KinematicState ks; 
	private Vector3 initpos;

	// Use this for initialization
	void Start () {
		ks = target.GetComponent<KinematicState> ();
		initpos = this.transform.position;
	}

	// Update is called once per frame
	void Update () {
		float x = Mathf.Abs (ks.linearVelocity.x);
		float y = Mathf.Abs (ks.linearVelocity.y);

		float nx = Mathf.Repeat (Time.time * x, this.GetComponent<SpriteRenderer>().sprite.texture.width);
		float ny = Mathf.Repeat (Time.time * y, this.GetComponent<SpriteRenderer>().sprite.texture.height);

		nx = nx * Mathf.Sign (ks.linearVelocity.x);
		ny = ny * Mathf.Sign (ks.linearVelocity.y);

		Vector3 newPos = initpos + new Vector3 (nx, ny, 0);

		this.transform.position = newPos;

	}
}
