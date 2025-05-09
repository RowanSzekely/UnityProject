using System.Collections;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField] GameObject fadeInScreen;
    [SerializeField] GameObject fadeOutScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MySequence(){

        yield return new WaitForSeconds(0.5f);
        fadeInScreen.SetActive(false);
        yield return new WaitForSeconds(10);
        fadeOutScreen.SetActive(true);

    }
}
