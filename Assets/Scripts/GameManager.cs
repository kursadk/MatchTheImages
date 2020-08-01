using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Sprite> spriteList = new List<Sprite>(6);

    [SerializeField] List<Button> buttonList = new List<Button>(12);
    List<Button> matchedButtonList = new List<Button>(12);

    List<Button> shadowButtonList;
    Dictionary<String, Sprite> map = new Dictionary<String, Sprite>();
    Dictionary<Button, String> matchedButtons = new Dictionary<Button, String>();

    String firstSpriteName = "";
    String secondSpriteName = "";

    Button firstButton;
    Button secondButton;



    int clickedCount = 0;
    public void imageOnClick(Button clickedButton)
    {
        
        clickedCount += 1;
        clickedCount = clickedCount % 3;
        if (clickedCount == 0)
        {
            if(firstSpriteName == secondSpriteName)
            {
                matchedButtonList.Add(firstButton);
                matchedButtonList.Add(secondButton);
                firstButton = null;
                secondButton = null;
                firstSpriteName = "";
                secondSpriteName = "";

            }
            foreach (Button button in buttonList)
            {
                if (!matchedButtonList.Contains(button))
                    button.GetComponent<Image>().sprite = null;

            }
        }
        else
        {
            clickedButton.GetComponent<Image>().sprite = map[clickedButton.name];
            if(clickedCount == 1)
            {
                firstSpriteName = map[clickedButton.name].name;
                firstButton = clickedButton;
                
            }
            else
            {
                secondSpriteName = map[clickedButton.name].name;
                secondButton = clickedButton;

            }
                

        }
        Debug.Log("The button clicked was " + clickedButton.name);
        
       

    }
    // Start is called before the first frame update
    void Start()
    {
        
        shadowButtonList = new List<Button> (buttonList);

        
        for (int i = 0; i < spriteList.Count; i++)
        {
            int buttonIndex = UnityEngine.Random.Range(0, shadowButtonList.Count);
            map.Add(shadowButtonList[buttonIndex].name, spriteList[i]);
            shadowButtonList.RemoveAt(buttonIndex);

            buttonIndex = UnityEngine.Random.Range(0, shadowButtonList.Count);
            map.Add(shadowButtonList[buttonIndex].name, spriteList[i]);
            shadowButtonList.RemoveAt(buttonIndex);
      
        
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
