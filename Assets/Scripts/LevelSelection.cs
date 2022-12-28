using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;

    private int FirstLevelSceneIndex = 2;

    // Start is called before the first frame update
    //Original creator of code part: https://www.youtube.com/@VinnyGameDev
    //code start
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", FirstLevelSceneIndex); /* < Change this int value to whatever your
                                                             level selection build index is on your
                                                             build settings */

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > levelAt)
                lvlButtons[i].interactable = false;
        }
    }
    //code end


    //resets progress and locks levels aside from level 1
    public void ClearProgress()
    {
        PlayerPrefs.SetInt("levelAt", FirstLevelSceneIndex);
    }

}
