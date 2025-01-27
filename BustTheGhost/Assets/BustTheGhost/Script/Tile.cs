using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Tile : MonoBehaviour{

    public enum TileKind{ 
        Blank,
        Ghost, 
        Clue
    }

    public bool iscovered = true;
    public Sprite coveredSprite;
    public TileKind tileKind = TileKind.Blank;
    public TextMeshPro probability;
    public Sprite backgroundImage;
    private Sprite defaultSprite;

    void Start(){ 
        defaultSprite = GetComponent<SpriteRenderer>().sprite; 
        GetComponent<SpriteRenderer>().sprite = coveredSprite;
        
        GameObject background = new GameObject("Background");
        background.transform.SetParent(probability.transform, false);
        background.transform.SetAsFirstSibling(); // Move it behind the probability text
        background.transform.localPosition = new Vector3(0, 0, 1); // Move it slightly behind the text

        // Add an Image component and set the backgroundImage as the sprite
        Image backgroundImg = background.AddComponent<Image>();
        backgroundImg.sprite = backgroundImage;
    }

    public void SetIsCovered (bool covered){ 
        iscovered=false; 
        GetComponent<SpriteRenderer>().sprite=defaultSprite; 
 
    }
    
    public void HideProbability() {
        Color tempColor = probability.color;
        tempColor.a = 0f; // Set alpha to 0
        probability.color = tempColor;
    }

    public void ShowProbability() {
        Color tempColor = probability.color;
        tempColor.a = 1f; // Set alpha to 1
        probability.color = tempColor;
    }
}
