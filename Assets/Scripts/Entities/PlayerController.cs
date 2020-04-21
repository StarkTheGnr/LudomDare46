using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;

    [SerializeField]
    private float speed = 5f, mouseSensitivity = 5f, jumpPower = 5f, gravity = -9.8f;

    [SerializeField]
    private float minVerticalRotation = -65f, maxVerticalRotation = 180f;

    private float currCamRotV;

    Vector3 moveDir = Vector3.zero;

    public AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        MouseMovement();
        KeyboardMovement();
    }

    void KeyboardMovement()
    {
        if (cc.isGrounded)
        {
            float haxis = Input.GetAxis("Horizontal");
            float vaxis = Input.GetAxis("Vertical");

            moveDir = transform.rotation * new Vector3(haxis, 0f, vaxis) * speed;
            moveDir.y = 0;

            if (Input.GetButton("Jump"))
            {
                jumpSound.Play();
                moveDir.y = jumpPower;
            }
        }

        moveDir.y += gravity * Time.deltaTime;

        cc.Move(moveDir * Time.deltaTime);
    }

    void MouseMovement()
    {
        float haxis = Input.GetAxis("Mouse X") * mouseSensitivity;
        currCamRotV += Input.GetAxis("Mouse Y") * mouseSensitivity;

        currCamRotV = Mathf.Clamp(currCamRotV, minVerticalRotation, maxVerticalRotation);

        transform.eulerAngles = new Vector3(-currCamRotV, transform.eulerAngles.y + haxis, 0);
    }
}
