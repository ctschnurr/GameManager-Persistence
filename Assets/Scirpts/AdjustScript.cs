using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustScript : MonoBehaviour
{
    private void OnGUI()
    {
        if(GUI.Button(new Rect(10, 250, 100, 30), "Health Up"))
        {
            GameManager.control.health += 10;
        }
        if (GUI.Button(new Rect(120, 250, 100, 30), "Health Down"))
        {
            GameManager.control.health -= 10;
        }
        if (GUI.Button(new Rect(10, 290, 100, 30), "XP Up"))
        {
            GameManager.control.experience += 10;
        }
        if (GUI.Button(new Rect(120, 290, 100, 30), "XP Down"))
        {
            GameManager.control.experience -= 10;
        }
        if (GUI.Button(new Rect(10, 330, 100, 30), "Score Up"))
        {
            GameManager.control.score += 10;
        }
        if (GUI.Button(new Rect(120, 330, 100, 30), "Score Down"))
        {
            GameManager.control.score -= 10;
        }
        if (GUI.Button(new Rect(10, 370, 100, 30), "Gold Up"))
        {
            GameManager.control.gold += 1;
        }
        if (GUI.Button(new Rect(120, 370, 100, 30), "Gold Down"))
        {
            GameManager.control.gold -= 1;
        }
        if (GUI.Button(new Rect(10, 410, 100, 30), "Potions Up"))
        {
            GameManager.control.potions += 1;
        }
        if (GUI.Button(new Rect(120, 410, 100, 30), "Potions Down"))
        {
            GameManager.control.potions -= 1;
        }
        if (GUI.Button(new Rect(10, 450, 100, 30), "Kills Up"))
        {
            GameManager.control.kills += 1;
        }
        if (GUI.Button(new Rect(120, 450, 100, 30), "Kills Down"))
        {
            GameManager.control.kills -= 1;
        }

        if (GUI.Button(new Rect(10, 500, 100, 30), "Save"))
        {
            GameManager.control.Save();
        }
        if (GUI.Button(new Rect(120, 500, 100, 30), "Load"))
        {
            GameManager.control.Load();
        }

        // GUI.Label(new Rect(10, 10, 340, 30), "Scene: " + sceneNumber);
    }
}
