using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    //Rigidbody componenet for the player
    private Rigidbody2D rb;

    //Dash parameters
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    private float dashTime;
    private float dashCooldownTime;

    private bool isDashing = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleDash();
    }

    void HandleDash()
    {
        if (isDashing)
        {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0 )
            {
                isDashing = false;

                //Stop the dash movement
                rb.velocity = Vector3.zero;

                //Start the cooldown
                dashCooldownTime = dashCooldown;
            }
        }

        else
        {
            dashCooldownTime -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space)&& dashCooldownTime <= 0)
            {
                //Start Dashing
                isDashing = true;
                dashTime = dashDuration;

                Vector2 dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
                rb.velocity = dashDirection * dashSpeed;

            }
        }
    }
}
