using UnityEngine;

public class TextScript : MonoBehaviour
{
    [SerializeField] GameObject cornerText;

    public Health playerHealth;
    
    GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth == null){
            playerHealth = player.GetComponent<Health>();
        }
        int displayableHealth = playerHealth.CurrentHealth;
        if(playerHealth != null){
            cornerText.GetComponent<TMPro.TMP_Text>().text = "Health: " + displayableHealth;
        }
        else{
            cornerText.GetComponent<TMPro.TMP_Text>().text = "You are dead";
        }
    }
}
