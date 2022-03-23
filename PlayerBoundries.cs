using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundries : MonoBehaviour
{
    private Vector2 boundries;
    private float playerWidth;
    private float playerHeight;
    void Start()
    {
        boundries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        playerWidth = GetComponent<SpriteRenderer>().bounds.size.x/2;
        playerHeight = GetComponent<SpriteRenderer>().bounds.size.y/2;

    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -boundries.x + playerWidth, boundries.x - playerWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, -boundries.y + playerHeight, boundries.y - playerHeight);
        transform.position = viewPos;
    }
}
