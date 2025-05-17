using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5;
    public float horizontaolSpeed = 3;
    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;

    public float dragSpeed = 0.01f;
    public float jumpForce = 7f;
    public float xMin = -3f;
    public float xMax = 3f;

    private Rigidbody rb;
    private Vector3 touchStart;
    private bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    private int jumpCount = 0;
    public int maxJumps = 2;
    private bool isDragging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontaolSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontaolSpeed);
            }
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
            isDragging = false;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 delta = (Vector3)Input.mousePosition - touchStart;

            if (Mathf.Abs(delta.x) > 5f) // Sensitivity threshold
            {
                isDragging = true;
                touchStart = Input.mousePosition;
                MovePlayer(delta.x);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (!isDragging)
                TryJump();
        }
#else
    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            touchStart = touch.position;
            isDragging = false;
        }
        else if (touch.phase == TouchPhase.Moved)
        {
            Vector3 delta = (Vector3)touch.position - touchStart;

            if (Mathf.Abs(delta.x) > 5f) // Movement threshold
            {
                isDragging = true;
                touchStart = touch.position;
                MovePlayer(delta.x);
            }
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            if (!isDragging)
                TryJump();
        }
    }
#endif
    }
    void MovePlayer(float deltaX)
    {
        float moveAmount = deltaX * dragSpeed;
        Vector3 newPos = transform.position + new Vector3(moveAmount, 0f, 0f);
        newPos.x = Mathf.Clamp(newPos.x, xMin, xMax);
        transform.position = newPos;
    }

    void TryJump()
    {
        if (jumpCount < maxJumps)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce,0);
            jumpCount++;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }
}
