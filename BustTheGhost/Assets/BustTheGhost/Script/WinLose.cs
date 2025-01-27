using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WinLose : MonoBehaviour{
    private Sprite gameoverimgl;
    public UnityEvent buttonClicked; 
    public Sprite btn;
    public Game var;
    public int score = 50; // Initial credit
    public int allowedBusts = 3; // Number of busts allowed
    public int flag=1;
    public TMPro.TextMeshProUGUI scoreText, allowedBustsText;
    public GameObject gameOverImage, winImage;

    void Awake(){ 
        if (buttonClicked == null){
            buttonClicked =  new UnityEvent();  
        }
    }

    void Start(){  
        var = FindObjectOfType(typeof(Game)) as Game;
        allowedBustsText.text = "Remaining Busts: " + 3;
        scoreText.text = "Remaining Score: " + 50;
    }

    void Update(){
        if(flag==1){
            CheckInput();
            var.CheckInputGrid();
        }
    }
   
    private void CheckInput(){       
        if(Input.GetButtonDown("Fire1")){  
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int a = Mathf.RoundToInt(mousePosition.x);
            int b = Mathf.RoundToInt(mousePosition.y);
            if((a<=7 && 0<=a) || (b <=13 && 0<=a)){      
                score--;
                // Update and display the remaining credit
                Debug.Log("Remaining Score: " + score);
                scoreText.text = "Remaining Score: " + score;

                // Check if the player has lost
                if (score <= 0){
                    Debug.Log("You run out of credits! Sorry to see you loose! GAME OVER !");
                    gameOverImage.SetActive(true);
                    flag=0;
                    return;
                }
            }
            else{
                allowedBusts--;
                Debug.Log("Remaining busts: " + allowedBusts);
                allowedBustsText.text = "Remaining Busts: " + allowedBusts;

                if (allowedBusts < 0){
                    Debug.Log("You run out of busts! Sorry to see you loose! GAME OVER!");
                    gameOverImage.SetActive(true);
                    flag = 0;
                    return;
                }

                if (allowedBusts <= 0 && var.lastClickedX != var.GhostX && var.lastClickedY != var.GhostY){
                    Debug.Log("You run out of busts! Sorry to see you loose! GAME OVER!");
                    gameOverImage.SetActive(true);
                    flag = 0;
                    return;
                }

                if (var.lastClickedX == var.GhostX && var.lastClickedY == var.GhostY){
                    Debug.Log("You busted the ghost! BRAVO, YOU WON!");
                    winImage.SetActive(true);
                    flag=2;
                    return;
                }
            }
        }
    }
}
