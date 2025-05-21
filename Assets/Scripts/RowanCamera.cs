using UnityEngine;

public class RowanCamera : MonoBehaviour
{
    public float radiusFromTarget;

    public float heightToTopRing;

    public float heightToBotRing;

    
    public Transform target;

    public float sensitivity;

    private Vector2 cameraInput;


    private float _height;

    private float _yawRot;

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
        cameraInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    private void _MoveCamera()
    {
        Vector3 yawOnlyOffset_wld;
        {
            _yawRot += cameraInput.x * sensitivity;
            Quaternion wld_RotYawOnly_wld = Quaternion.Euler(0, _yawRot, 0);
            yawOnlyOffset_wld = wld_RotYawOnly_wld * (Vector3.forward * radiusFromTarget);
        }

        {
            _height += cameraInput.y * .01f * sensitivity;
            _height = Mathf.Clamp(_height, heightToBotRing, heightToTopRing);
        }

        Vector3 look_wld = yawOnlyOffset_wld;
        look_wld.y = _height;

        transform.position = target.position - look_wld;
        transform.rotation = Quaternion.LookRotation(look_wld.normalized, Vector3.up);

        if (poseableTarget != null)
        {
            poseableTarget.SetLookDirection(yawOnlyOffset_wld.normalized);
        }

    }
}
