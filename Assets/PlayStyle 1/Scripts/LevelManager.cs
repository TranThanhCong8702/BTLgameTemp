using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI EndingText;
    // Start is called before the first frame update
    public void levelloaded(string name)
    {
        //print("Level muon den la :"+name);
        SceneManager.LoadScene(name);
        FindObjectOfType<GameSession>().DestroyGameSession();
        //FindObjectOfType<ScenePersist>().ResetscenePersist();
    }
    void EndingLine()
    {
        string check = FindObjectOfType<GameSession>().LoadExit();
        if (check == "0")
        {
            EndingText.text = "YOU LOSE!";
        }
        else
        {
            EndingText.text = "Congatulation, You are the champion";
        }
    }
    private void Start()
    {
        EndingLine();
    }
}
