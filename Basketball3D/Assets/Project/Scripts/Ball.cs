using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Ball : MonoBehaviour
{
    public GameObject trailObject;
    public float range=10f;
    Collider[] collidersin;
    public GameObject playercamera;
    public Player player;
    private bool check;
    public ScoreArea scoreArea;
    void Start()
    {
        trailObject.SetActive(false);
    }

    void FixedUpdate()
    {
        collidersin=Physics.OverlapSphere(this.transform.position, range);
        foreach(var a in collidersin)
        {
            if (a.name == "Player")
            {
                
                check = true;
            }
        }
    }

    private void Update()
    {
        if (check) {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.holdingBall = true;
                trailObject.SetActive(false);
                check = false;
                scoreArea.DisableEffect();
            }
        }
    }
    public void ActivateTrail()
    {
        trailObject.SetActive(true);
    }
}
