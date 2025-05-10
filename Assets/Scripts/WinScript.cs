using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject winScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SurviveTimer());
    }

    // Update is called once per frame
    private IEnumerator SurviveTimer()
    {
        yield return new WaitForSeconds(15);
        if(player.activeSelf == true){
            winScreen.SetActive(true);
            
        }
    }
}
