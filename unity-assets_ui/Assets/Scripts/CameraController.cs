
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public Transform Player;

    public bool isInverted = false;
    private float AngleRotation = 45f;

    private Vector3 DistanceApart = Vector3.zero;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;


    private void Awake()
    {
         
        DistanceApart = transform.position - Player.position;
    
}

    private void Update()
    {
        FollowPlayer();
        RotateAroundPlayer();
    }

    void RotateAroundPlayer()
    {
        rotationX += Input.GetAxis("Mouse X") * AngleRotation * Time.deltaTime;

        float mouseY = Input.GetAxis("Mouse Y");
        if (isInverted)
        {
            rotationY += mouseY * AngleRotation * Time.deltaTime;
        }
        else
        {
            rotationY -= mouseY * AngleRotation * Time.deltaTime;
        }

            Quaternion rotation = Quaternion.Euler(0, rotationX, 0);

        transform.rotation = rotation;

        transform.position = Player.position - (rotation * new Vector3(0, 0, 5));


        // transform.RotateAround(Player.position, Vector3.up,   RotationYDirection * AngleRotation * Time.deltaTime);
        transform.LookAt(Player);
        transform.rotation = rotation;
    }

    void FollowPlayer()
    {
        transform.position = Player.transform.position + DistanceApart;
    }
}