using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingController : MonoBehaviour
{
  [Header("Input Settings")]
  public int playerID;
  private bool isGrounded;

  [Header("Character Statistics")]
  public Vector3 movementDirection;
  private float movementSpeed;

  [Header("Refrences")]
  public Rigidbody rb;
  public Animator animator;

  [Space]
  [Header("Character Attributes")]
  public float MOVEMENT_BASE_SPEED = 1.0f;
  public float JUMP_FORCE = 2.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      ProcessInputs();
      Move();
      Animate();
    }

    void ProcessInputs() {
      movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
      //(Clamp value, min, max)
      movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 0.5f);
      movementDirection.Normalize();
    }

    void Move() {
      if(Input.GetButtonDown("Fire2") && isGrounded){
        Debug.Log(isGrounded);
      }
      //rb.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
      transform.position = transform.position + movementDirection * MOVEMENT_BASE_SPEED * Time.deltaTime;
      //rb.AddForce(1, -200, 1);
      if(Input.GetButtonDown("Jump") && isGrounded){
        rb.AddForce(new Vector3(0,1,0) * JUMP_FORCE, ForceMode.Impulse);
        //rb.velocity = Vector3.up * JUMP_FORCE;
        isGrounded = false;
      }
    }

    void Animate() {
      if (movementDirection != Vector3.zero) { // Keep facing position after letting go of controls
        animator.SetFloat("Horiz", movementDirection.x);
        animator.SetFloat("Vert", movementDirection.z);
      }
      animator.SetFloat("Speed", movementSpeed);
    }

    void OnCollisionEnter(Collision collision){
      if (collision.gameObject.name == "Plane"){
        isGrounded = true;
      }
    }
}
