using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    public Sprite initialSprite;
    public Sprite triggeredSprite;
    private SpriteRenderer checkpointSpriteRenderer;
    public bool checkpointReached;
	// Use this for initialization
	void Start () {
        checkpointSpriteRenderer = GetComponent<SpriteRenderer>(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            checkpointSpriteRenderer.sprite = triggeredSprite;
            checkpointReached = true;
        }
    }
}
