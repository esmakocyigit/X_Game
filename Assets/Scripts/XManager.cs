using System.Collections.Generic;
using UnityEngine;

public class XManager : MonoBehaviour
{
    public int counter = 0;
    public bool count;
    private GridManager gridManager;

    public List<GameObject> activex =new List<GameObject>();

    private void Start()
    {
        gridManager = GameObject.Find("GridManager").GetComponent<GridManager>();

    }

    private void LateUpdate()
    {
        if (gameObject.activeInHierarchy && !count)
        {
            counter = 0;
            count = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        XManager xTag = other.GetComponent<XManager>();

        if (xTag != null)
        {
            counter++;
            if (counter >= 2)
            {
                gameObject.SetActive(false);
                counter = 0;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        XManager xTag = other.GetComponent<XManager>();

        if (xTag != null)
        {
            gameObject.SetActive(false);
            count = false;
            if (counter >= 2)
                gridManager.ScoreCounter++;


            counter = 0;
        }
    }

}
