using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    public Vector2  turn;
    public float sensitivity = .5f;
    // public Vector3 deltaMove;
    // public float speed = 1;
    // public gameOject mover;
    // Start is called before the first frame update
    void Start()
    {
        // Cursor.lockState = CursorLockMode.locked;    
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        // mover.transform.localRotation = Quaternion.Euler(0, turn.x, 0);
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        // deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        // mover.transform.Translate(deltaMove);
    }
}
