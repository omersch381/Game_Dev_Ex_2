using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    public GameObject playerCamera;
    private CharacterController controller;
    private float speed = 0.3f;
    private float rx = 0, ry;
    private float angularSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx, dz;

        // Mouse
        rx -= Input.GetAxis("Mouse Y") * angularSpeed;
        ry = transform.localEulerAngles.y + Input.GetAxis("Mouse X");
        playerCamera.transform.localEulerAngles = new Vector3(rx, 0, 0);
        transform.localEulerAngles = new Vector3(0, ry, 0);

        // Keyboard
        dx = Input.GetAxis("Horizontal") * speed;
        dz = Input.GetAxis("Vertical") * speed;
        
        Vector3 motion = new Vector3(dx,0,dz);
        motion = transform.TransformDirection(motion);
        controller.Move(motion);
    }
}
