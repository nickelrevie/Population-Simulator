using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public int speed = 5;
    public Camera camera_component;

	// Use this for initialization
	void Start () {
        camera_component = this.gameObject.GetComponent<Camera>();
        camera_component.orthographicSize = 5; //Changes the zoom to 5
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        //Users can have more than one key input at a time.
        if (Input.GetKey(KeyCode.A)) //Move camera to the left.
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D)) //Move camera to the right.
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.W)) //Move camera forward.
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S)) //Move camera backward.
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) //Scrolling down on the mouse wheel zooms out.
        {
            camera_component.orthographicSize++;
            speed = (int)camera_component.orthographicSize;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f) // Scrolling up on the mouse wheel zooms in.
        {
            if (camera_component.orthographicSize > 1) //Stops zooming in if the camera gets too close to the map.
            {
                camera_component.orthographicSize--;
                speed = (int)camera_component.orthographicSize;
            }
        }
    }
}
