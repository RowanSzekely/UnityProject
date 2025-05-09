using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector3 playerMoveInput;
    private Vector2 playerMouseInput;

    private float xRot;

    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private Transform playerCamera;

    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveSensitivity;

    // Update is called once per frame
    void Update()
    {
       playerMoveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
       playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

       MovePlayer();
       MoveCamera();
    }

    private void MovePlayer(){
        Vector3 movePlayer = transform.TransformDirection(playerMoveInput) * moveSpeed;
        playerBody.linearVelocity = new Vector3(movePlayer.x, playerBody.linearVelocity.y, movePlayer.z);

        if(Input.GetKeyDown(KeyCode.Space)){
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    private void MoveCamera(){
        xRot -= playerMouseInput.y * moveSensitivity;
        transform.Rotate(0f, playerMouseInput.x * moveSensitivity, 0f);
        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);



    }
}
