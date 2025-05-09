using UnityEngine;

public class OpenGate : MonoBehaviour
{
    [SerializeField] GameObject gate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTheGate(){
        gate.GetComponent<Animator>().Play("GateSwing");
    }
}
