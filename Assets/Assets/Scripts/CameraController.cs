using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public int speed = 5;
    public Camera camera_component;

	// Use this for initialization
	void Start () {
        camera_component = this.gameObject.GetComponent<Camera>();
        camera_component.orthographicSize = 5;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) //forward
        {
            camera_component.orthographicSize++;
            speed = (int)camera_component.orthographicSize;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f) // backwards
        {
            if (camera_component.orthographicSize > 1)
            {
                camera_component.orthographicSize--;
                speed = (int)camera_component.orthographicSize;
            }
        }
    }
}
