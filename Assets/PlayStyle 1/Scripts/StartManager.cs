using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public void levelloaded(string name)
    {
        //print("Level muon den la :"+name);
        SceneManager.LoadScene(name);
        //FindObjectOfType<GameSession>().DestroyGameSession();
        //FindObjectOfType<ScenePersist>().ResetscenePersist();
    }
}
