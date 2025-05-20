using UnityEngine;

public class SpawnSelectedPlayer : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject player;
    private int playerColour = FinalSelection.finalSelected;

    void Start()
    {
        if(playerColour == 0){
            player.GetComponent<Renderer>().material.color = Color.red;

        }else if(playerColour == 1){
            player.GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
