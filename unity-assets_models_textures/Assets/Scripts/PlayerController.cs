using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Transform cameraPosition;
    private Rigidbody rb;
    private Vector3 vertical;
    private Vector3 horizontaL;
    private float moveX;
    private float moveZ;
    private Vector3 InitialPosition;
    public CharacterController controller;

    private void Awake()
    {
        InitialPosition = transform.position;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        if (cameraPosition == null)
        {
            cameraPosition =   Camera.main.transform;
        }
    }

    void Update()
    {
        Move();
        Jump();
        CheckFall();
    }

    void Move()
    {
         moveX = Input.GetAxis("Horizontal");
         moveZ = Input.GetAxis("Vertical");

        Vector3 forward = cameraPosition.forward;
        Vector3 right = cameraPosition.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 move = new Vector3(moveX, 0, moveZ);
        rb.AddForce(move * (Time.deltaTime * moveSpeed));
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    void CheckFall()
    {
        Vector3 spaceGap = new Vector3(0, 3, 0);
        if (transform.position.y < -3f)
        {
            transform.position = InitialPosition + spaceGap;
        }
    }
}
