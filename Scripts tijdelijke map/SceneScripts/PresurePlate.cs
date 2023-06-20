using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PresurePlate : MonoBehaviour
{
    // maak een scene aan die ExitVidScene heet
    // Zet de scene in de build settings, net zoals voor de intro
    // maak een video map aan en sleep de video er in
    // maak in de assets een render texture aan
    // zet de size van de render texture naar 1920 x 1080 (size van intro cutscene)
    // maak in de hiarchy een videomaneger en UI raw image aan
    // zet de raw image naar full screen
    // sleep vanuit de assets de aangemaakte render texture in de texture van de raw image
    // ga nu naar de videomaneger, sleep de orignele mp4 video in de video clip en de render texture in de target texture
    // zet dit script op de player
    // zet in de script bij LevelLoaded: ExitVidScene
    // maak een empty game object aan met een 2d box collider
    // geef deze empty de tag EindBaas
    // nu moet het werken




    public string LevelLoaded;


    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EindBaas")
        {
            SceneManager.LoadScene(LevelLoaded);
        }
    }
}
