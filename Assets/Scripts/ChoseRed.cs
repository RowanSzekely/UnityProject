using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoseRed : MonoBehaviour
{

  
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){

            //FinalSelection.finalSelected = 0;
            SceneManager.LoadScene("PlayGame");
            
        }
    }

}
