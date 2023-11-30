using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject Ending;
    PlayerMovementType2 playerMovement;
    AudioSource audioSource;
    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovementType2>();
        audioSource = GetComponent<AudioSource>();
    }
    public void Pause()
    {
        GameObject.FindGameObjectWithTag("Start").gameObject.SetActive(false);
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void StopST()
    {
        Ending.SetActive(true);
    }
    public void EndST()
    {
        audioSource.Play();
        Invoke("Restart", 1f);
    }
    void Restart()
    {
        GameObject.FindGameObjectWithTag("Ending").gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
