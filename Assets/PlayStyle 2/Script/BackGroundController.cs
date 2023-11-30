using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundController : MonoBehaviour
{
    [SerializeField] List<Sprite> list = new List<Sprite>();
    [SerializeField] Image imagel;
    PlayerMovementType2 playerMovement;
    float temp;
    float tmp;
    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovementType2>();
    }
    void Start()
    {

    }
    // Update is called once per frame
    void LateUpdate()
    {

    }
    public void ChangeBackGround()
    {
        int i = Random.Range(0, list.Count);
        imagel.sprite = list[i];
        Debug.Log("Hello");
    }
}
