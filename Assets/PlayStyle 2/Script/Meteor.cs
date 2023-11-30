using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Meteor : MonoBehaviour
{
    [SerializeField] float flySpeed = 1f;
    [SerializeField] float flyTime = 1f;
    [SerializeField] Vector3 spawnPos;

    bool IsChange = false;
    Rigidbody2D rb;
    [SerializeField] GameObject Enemy;
    CamShake cam;
    GameControlType2 gameControlType;
    int count = 0;

    private void Awake()
    {
        cam = FindObjectOfType<CamShake>();
        gameControlType = FindObjectOfType<GameControlType2>();
    }
    void Start()
    {
        StartCoroutine(MeteorStart());
    }
    public bool getBool()
    {
        return IsChange;
    }
    IEnumerator MeteorStart()
    {
        yield return new WaitForSeconds(flyTime);
        transform.GetComponent<Animator>().SetBool("explode", true);
        Debug.Log("Explosion");
        if(count == 0)
        {
            gameControlType.PlayerProcess();
            count++;
        }
        cam.Play();
        IsChange = true;
        Invoke("Des", 1f);
    }
    public void Fire()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0,flySpeed);
    }
    // Update is called once per frame
    void Update()
    {
        Fire();
    }
    private void LateUpdate()
    {
        StartCoroutine(MeteorStart());
    }
    private void Destroy()
    {
        if (Vector2.Distance(transform.position, spawnPos) >= 18f)
        {
            Des();
        }
    }
    private void Des()
    {
        gameObject.SetActive(false);
        count = 0;
        //coll.enabled = true;
        transform.position = /*new Vector3(8.45f, -2.18f, 0)*/ spawnPos;
    }
}
