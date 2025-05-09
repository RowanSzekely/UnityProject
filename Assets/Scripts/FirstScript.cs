using UnityEngine;

public class FirstScript : MonoBehaviour
{
    [SerializeField] int myNum;
    [SerializeField] string myName;
    [SerializeField] bool myChoice;
    int myOtherNum;
    [SerializeField] GameObject myGate;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myNum = 4;
        myName = "Rowan";
        myChoice = true;
        myGate.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
