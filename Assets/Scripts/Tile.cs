using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameObject tile;
    private GameObject X;
    private Canvas tileCanvas;
    public Camera mainCamera;
    public bool isTrigger;
    private void Start()
    {
        X = gameObject.transform.GetChild(1).gameObject;
        tileCanvas = gameObject.transform.GetChild(0).gameObject.GetComponent<Canvas>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        tileCanvas.worldCamera = mainCamera;
        tile = gameObject;
        float x = tile.GetComponent<SpriteRenderer>().bounds.size.x;
    }
    public void clickButton()
    {
        X.SetActive(true);
    }
}
