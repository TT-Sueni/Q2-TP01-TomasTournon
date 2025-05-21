using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{

    [Header("Panels")]
    

    
    [SerializeField] private GameObject aim;
    [SerializeField] private Camera cam;
    bool aimON = true;
    

    Bullet bullet;

    [SerializeField] private TMP_Text showScore;
    


    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    private void Start()
    {
        if (cam == null)
            cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        Scoreboard(Bullet.score);
        if (Input.GetKeyDown(KeyCode.F) && !aimON)
        {
            aim.SetActive(true);
            aimON = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && aimON)
        {
            aim.SetActive(false);
            aimON = false;
        }
        
    }

    public void Scoreboard(int score)
    {
        string currentScore = score.ToString("F0");
        showScore.text = "Score : " + currentScore;
    }

  
   
 
   

   
}
