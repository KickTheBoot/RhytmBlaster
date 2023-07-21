using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(FpsLook)), RequireComponent(typeof(CharacterController))]
public class FpsMove : MonoBehaviour
{
    //Components
    FpsLook look;
    CharacterController charCont;

    Vector3 velocity = new Vector3(0, 0, 0);

    //Parameters
    [SerializeField, Min(0)] float speed = 5;
    [SerializeField, Min(0)] float jumpSpeed = 5;

    [SerializeField, Min(0)] float MaximumVelocity = 10;

    [SerializeField] float deceleration = 3;

    [SerializeField] Vector3 CharacterGravity = new Vector3(0, -1, 0);


    // Start is called before the first frame update
    void Start()
    {
        look = GetComponent<FpsLook>();
        charCont = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool grounded = charCont.isGrounded;

        Vector3 direction = Vector3.zero;
        direction += transform.forward * Input.GetAxis("Vertical");
        direction += transform.right * Input.GetAxis("Horizontal");

        velocity += direction * speed;



        if (grounded)
        {
            velocity.y = 0;
            if (Input.GetButton("Jump")) velocity.y += jumpSpeed;
        }
        else velocity += CharacterGravity * Time.deltaTime;

        velocity = Vector3.ClampMagnitude(velocity, MaximumVelocity);

        charCont.Move(velocity * Time.deltaTime);

    }
}
