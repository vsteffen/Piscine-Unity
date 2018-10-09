using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
	public float		speed;
	Vector3 _cameraOffset;
	private Vector3					moveVec;
	private CharacterController		cc;

	// Use this for initialization
	void Start () {
		_cameraOffset = Camera.main.transform.eulerAngles;
		cc = GetComponent<CharacterController>();
	}

	private void followMouse()
    {
		Camera _cam = Camera.main;

        Vector3 vec = _cam.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cam.nearClipPlane));
        float newRotationX = Camera.main.transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * speed;
        Camera.main.transform.localRotation = Quaternion.Euler(newRotationX + _cameraOffset.x, _cameraOffset.y, _cameraOffset.z);


        float newRotationY = Input.GetAxis("Mouse X") * (speed);
        transform.Rotate(0, newRotationY, 0);
    }

	// Update is called once per frame
	void Update () {
		followMouse();
		moveVec.z = Input.GetAxis("Vertical");
		moveVec.y = 0;
		moveVec.x = Input.GetAxis("Horizontal");
		Vector3 forward = transform.TransformDirection(moveVec);
		forward *= speed;
		forward.y = -9.81f;
		// if ((forward.x != 0 || forward.z != 0) && !_running && _runningNow) {
		// 	_moving = true;
		// 	AudioManager.instance.footsteps.Play();
		// 	_running = true;
		// }
		// if ((forward.x == 0 && forward.z == 0) && _moving) {
		// 	_moving = false;
		// 	_running = false;
		// 	AudioManager.instance.footsteps.Stop();
		// }
		cc.Move(forward * Time.deltaTime);
	}
}
