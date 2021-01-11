using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    private bool groundedPlayer;
    Vector3 velocity;

    public Transform floor;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //ClickMovement();
    }

    /**
     * Click Movement method for if the game ends up being 3rd person
    void ClickMovement()
    {
        int layerMask = 1 << 8;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            // Does the ray intersect any objects excluding the game piece layer
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                if(hit.transform == floor)
                {
                    var offset = hit.point - transform.position;
                    if(offset.magnitude > .1f)
                    {
                        offset = offset.normalized;
                        controller.Move(offset * speed * Time.deltaTime);
                    }
                }
            }
        }
    }
    **/
}
