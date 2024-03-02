using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 100f;
    public float speedBoostMultiplier = 5f;
    public float speedBoostDuration = 5f;
    public Vector2 move, mouseLook, joyStickLook;
    private Vector3 rotationTarget;
    public bool isPc;
    public Animator animator; // Reference to the Animator component

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnJoyStickLook(InputAction.CallbackContext context)
    {
        joyStickLook = context.ReadValue<Vector2>();
    }

    public void OnMouseLook(InputAction.CallbackContext context)
    {
        mouseLook = context.ReadValue<Vector2>();
    }

    void Update()
    {
        moveSpeed = 5f * speedBoostMultiplier;

        if (speedBoostDuration > 0f)
        {
            speedBoostDuration -= Time.deltaTime;
        }
        else
        {
            speedBoostMultiplier = 1f;
            speedBoostDuration = 0f;
        }

        if (isPc)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(mouseLook);
            if (Physics.Raycast(ray, out hit))
            {
                rotationTarget = hit.point;
            }

            movePlayerWithDirection();
        }
        else
        {
            if (joyStickLook.x == 0 && joyStickLook.y == 0)
            {
                playerMove();
            }
            else
            {
                movePlayerWithDirection();
            }
        }

        UpdateAnimator(); // Call the method to update the Animator state
    }

    // New method to update Animator state based on movement
    void UpdateAnimator()
    {
        bool isMoving = (move != Vector2.zero);
        animator.SetBool("IsMoving", isMoving);
    }


    public void IncreaseSpeed(float speedBoostMultiplier, float duration)
    {
        Debug.Log("Speed boost applied!"); // Add this line for debugging

        this.speedBoostMultiplier *= speedBoostMultiplier;
        this.speedBoostDuration += duration;
    }


    public void movePlayerWithDirection()
    {
        if (isPc)
        {
            var lookPos = rotationTarget - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            Vector3 aimDirection = new Vector3(rotationTarget.x, 0f, rotationTarget.z);

            if (aimDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.15f);
            }
        }
        else
        {
            Vector3 aimDirection = new Vector3(joyStickLook.x, 0f, joyStickLook.y);
            if (aimDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(aimDirection), 0.15f);
            }
            Vector3 movement = new Vector3(move.x, 0f, move.y);
            transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    public void playerMove()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.10f);
        }
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}