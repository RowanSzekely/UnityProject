using UnityEngine;

public class RowanCamera : MonoBehaviour
{
    public Vector3 offsetFromTarget_cam;

    
    public Transform target;

    public float sensitivity;

    private Vector2 cameraInput;


    private float pitchRot;

    private ICameraPosable poseableTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Assert(GetComponent<Camera>() != null, "Camera script was not on camera game object.");
        Debug.Assert(sensitivity > .01f, "Sensetivity too low");
        poseableTarget = (ICameraPosable) target.GetComponent(typeof(ICameraPosable));
    }

    // Update is called once per frame
    void Update()
    {
        _CollectInput();
        _MoveCamera();
    } 
    
    private void _CollectInput()
    {
        cameraInput = new Vector2(Input.GetAxis("Mouse X"), 0f /* Input.GetAxis("Mouse Y") */);
    }

    private void _MoveCamera()
    {
        pitchRot -= cameraInput.y * sensitivity;
        float yawRot = cameraInput.x * sensitivity;
        transform.Rotate(0f, yawRot, 0f);
        // transform.localRotation = Quaternion.Euler(pitchRot, 0f, 0f);

        Vector3 offset_wld = transform.TransformDirection(offsetFromTarget_cam);
        transform.position = target.position + offset_wld;

        if (poseableTarget != null)
        {
            Vector3 look_wld = transform.forward;
            look_wld.y = 0;
            look_wld.Normalize();
            poseableTarget.SetLookDirection(look_wld);
        }

    }
}
