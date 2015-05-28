using UnityEngine;
using System.Collections;

public class BulletMechanics : MonoBehaviour {

	public float speed;
	private Vector2 unitVector;
	private Vector3 origin;

	void Start() {
		origin = transform.localPosition;
		//unitVector = new Vector2(1, 0);
	}
	

	/**
	*The bulllet will update its location here
	*/
	void Update() {
		if (getMagnitudeFromOrigin() > 10) {
			Destroy(gameObject);		
		}

		Rigidbody2D rigid = GetComponent<Rigidbody2D> ();
		rigid.velocity = speed * unitVector;



	}

	public void setDirection(Vector2 direction) {
		unitVector = direction;
	} 


	private float getMagnitudeFromOrigin() {
		float x = transform.localPosition.x - origin.x;
		float y = transform.localPosition.y - origin.y;
		return Mathf.Sqrt(x * x + y * y);


	}

	void OnCollisionEnter2D(Collision2D collider) {
		Destroy (gameObject);
	}

}
