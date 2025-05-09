using UnityEngine;

public class HideButton : MonoBehaviour
{

    [SerializeField] GameObject firstButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideButtonNow(){
        firstButton.SetActive(false);
    }
}
