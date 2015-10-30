using UnityEngine;
using System.Collections;

public class SuperSphereScript : MonoBehaviour {
	//Float value for speed used for moving Sphere
	float speed = 0.2f;
	//bool isMoving = true;
	float y;
	float x;
	delegate void SphereDelegate();
	SphereDelegate sphereDelegate;

	//variable to grab the gameobject we will manipulate
	public GameObject mySphere;

	void Awake(){
		//initialize the sphere settings prior to the script component being loaded
		mySphere = gameObject;
		sphereDelegate += moveSphere;
	}
	// Use this for initialization or initial actions characters & enemies will start off doing
	void Start () {

	}
	
	// Update is called once per frame (can vary per frame)
	void Update () {
	}

	//Fixed Update is called consistently so that physics does not get affected by frame rate
	void FixedUpdate(){
		sphereDelegate ();
		/* Old Code used to control the position and Movement of the sphere for reference
		 * if (mySphere.transform.position.x <= 10 & isMoving == true) {
			transform.Translate(Vector3.right * speed);
		}
		
		if (isMoving == false & mySphere.transform.position.x > 0) {
			transform.Translate(Vector3.left * speed);
		}
		*/

	}

	void moveSphere(){
		//If there is no change in the axes, DON'T update the position of the sphere for efficiency!

		//X Axis
		if (Input.GetAxis("Horizontal") != 0) {
			string xString;
			x = x + (Input.GetAxis ("Horizontal") * speed);
			transform.position = new Vector3 (x, y, 0);
			xString = string.Format ("The Sphere moved on the x axis... {0} units.", x);
			Debug.Log (xString);
		}

		//Y Axis
		if (Input.GetAxis("Vertical") != 0) {
			string yString;
			y = y + (Input.GetAxis ("Vertical") * speed);
			transform.position = new Vector3 (x, y, 0);
			yString = string.Format ("The Sphere moved on the y axis... {0} units.", y);
			Debug.Log (yString);
		}

		//mobile device input
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			
			// Move object across XY plane
			transform.Translate(touchDeltaPosition.x * speed * 0.5f, touchDeltaPosition.y * speed * 0.5f, 0);

			//Output movement in Debug
			if(touchDeltaPosition.x > 0){
				string xString;
				xString = string.Format ("The Sphere moved on the x axis... {0} units.", touchDeltaPosition.x);
				Debug.Log (xString);
			}
			if(touchDeltaPosition.y > 0){
				string yString;
				yString = string.Format ("The Sphere moved on the y axis... {0} units.", touchDeltaPosition.y);
				Debug.Log (yString);
			}
		}
	}
}
