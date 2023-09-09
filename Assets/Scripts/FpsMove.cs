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
    [SerializeField, Min(0)] float acceleration = 40;
    [SerializeField, Min(0)] float aerialAcceleration = 20;

    [SerializeField, Min(0)] float jumpSpeed = 5;

    [SerializeField, Min(0)] float MaximumHorizontalVelocity = 10;

    [SerializeField] float deceleration = 3;
    [SerializeField] float aerialDecerelation = 3;

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

        velocity += direction * (grounded ? acceleration : aerialAcceleration) * Time.deltaTime;


        if (!grounded) velocity += CharacterGravity * Time.deltaTime;
        else
        {
            if (Input.GetButton("Jump")) velocity.y += jumpSpeed;
            if(velocity.y < 0) velocity.y = 0;
        }

        Vector2 HorizontalVelocity =  Vector2.ClampMagnitude(new Vector2(velocity.x, velocity.z),MaximumHorizontalVelocity);
        HorizontalVelocity -= HorizontalVelocity.normalized * Time.deltaTime * (grounded ? deceleration : aerialDecerelation);

        velocity.x = HorizontalVelocity.x;
        velocity.z = HorizontalVelocity.y;
        //velocity = Vector3.ClampMagnitude(velocity, MaximumHorizontalVelocity);

        charCont.Move(velocity * Time.deltaTime);

    }
}
