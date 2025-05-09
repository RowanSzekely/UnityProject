using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    [SerializeField] private Transform playerCamera;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float sensitivity;

    [SerializeField]
    private bool isGrounded;

    private Vector3 moveInput;
    private Vector2 cameraInput;

    private float xRot;

 
    static LayerMask GROUND_LAYERS;

    void Start()
    {
        GROUND_LAYERS = 1 << LayerMask.NameToLayer("Ground");
        Debug.Log("Ground Mask: " + GROUND_LAYERS
        + "  \n  myLayer: " + gameObject.layer);   
        isGrounded = false;
    }

    void OnCollisionStay(Collision collisionInfo){
        if (( GROUND_LAYERS & (1 << collisionInfo.collider.gameObject.layer)) != 0)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(){
        isGrounded = false;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
       moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
       cameraInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

       MovePlayer();
       MoveCamera();
    }

    private void MovePlayer()
    {
        Vector3 movementAmount = transform.TransformDirection(moveInput) * speed;
        player.linearVelocity = new Vector3(movementAmount.x, player.linearVelocity.y, movementAmount.z);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            player.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }

    private void MoveCamera(){
        xRot -= cameraInput.y * sensitivity;
        transform.Rotate(0f, cameraInput.x * sensitivity, 0f);
        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

    }
}
