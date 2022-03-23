using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHit : MonoBehaviour
{
    public Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    public void TakeHit()
    {
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        cam.backgroundColor = new Vector4(.1f, 0, 0, 1);
        yield return new WaitForSeconds(.5f);
        cam.backgroundColor = Color.black;
    }
}
