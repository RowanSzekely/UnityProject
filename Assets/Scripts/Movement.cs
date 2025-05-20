using Unity.Mathematics;
using UnityEngine;

public class Movement : MonoBehaviour, ICameraPosable
{
    public struct InputData
    {
        public float forward;
        public float right;
        public bool jump;

        public void Reset()
        {
            forward = 0;
            right = 0;
            jump = false;
        }
    }

    [SerializeField] private Rigidbody player;
    [SerializeField] private Transform playerCamera;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float sensitivity;

    [SerializeField] private bool isGrounded;


    private InputData inputData;
    private Vector2 cameraInput;
    private float xRot;

 
    static LayerMask GROUND_LAYERS;

    void Start()
    {
        GROUND_LAYERS = 1 << LayerMask.NameToLayer("Ground");
        Debug.Log("Ground Mask: " + GROUND_LAYERS
        + "  \n  myLayer: " + gameObject.layer);
        isGrounded = false;

        inputData.Reset();
    }

    void OnCollisionStay(Collision collisionInfo){
        if (( GROUND_LAYERS & (1 << collisionInfo.collider.gameObject.layer)) != 0)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collisionInfo){
        if(( GROUND_LAYERS & (1 << collisionInfo.collider.gameObject.layer)) == 0 )
        {
            isGrounded = false;
        }
    }

    void Update()
    {
        _CollectInput();
    }

    void FixedUpdate()
    {
        _CollectInput();
       _MovePlayer();

       cameraInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    public void SetLookDirection(Vector3 forward_wld)
    {
        transform.rotation = quaternion.LookRotation(forward_wld, Vector3.up);
    }

    private void _CollectInput()
    {
        inputData.forward = Input.GetAxis("Vertical");
        inputData.right = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            inputData.jump = true;
        }
    }

    private void _MovePlayer()
    {
        Vector3 moveRaw_playerfrm = new Vector3(inputData.right, 0f, inputData.forward);
        Vector3 movementAmount_wld = transform.TransformDirection(moveRaw_playerfrm) * speed;
        player.linearVelocity = new Vector3(movementAmount_wld.x, player.linearVelocity.y, movementAmount_wld.z);

        if (inputData.jump)
        {
            Debug.Log("Jump " + Time.time);
            player.AddForce(Vector3.up * jumpForce, ForceMode.Force);
            isGrounded = false;
        }

        inputData.Reset();
    }


}
