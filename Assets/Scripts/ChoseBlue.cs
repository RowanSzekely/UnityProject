using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoseBlue : MonoBehaviour
{
  

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){

            //FinalSelection.finalSelected = 1;
            SceneManager.LoadScene("PlayGame");
            
        }
    }
}
