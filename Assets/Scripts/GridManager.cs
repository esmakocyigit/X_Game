using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    #region Variables

    public float ScoreCounter;


    [SerializeField] private Camera mainCamera;

    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject[] grid;

    [SerializeField] private Vector3 xOffset;
    [SerializeField] private Vector3 yOffset;

    [SerializeField] private int n;
    public float interval = 0.1f;

    private int Counter = 0;

    #endregion

    #region Monobeheviour CallBacks
    private void Awake()
    {
        Counter = 0;
        n = PlayerPrefs.GetInt("GridNumber");
        grid = new GameObject[n * n];
    }
    private void Start()
    {
        xOffset = (tilePrefab.transform.GetComponent<SpriteRenderer>().bounds.size.x + interval) * Vector3.right;
        yOffset = (tilePrefab.transform.GetComponent<SpriteRenderer>().bounds.size.y + interval) * Vector3.down;
        CameraMove();
        GridMaker();
    }
    #endregion

    #region Other Methods
    private void GridMaker()
    {

        for (int i = 0; i < n; i++)
        {
            grid[Counter] = Instantiate(tilePrefab, transform.position, Quaternion.identity);
            Counter++;
            for (int j = 0; j < n - 1; j++)
            {
                transform.position += xOffset;
                grid[Counter] = Instantiate(tilePrefab, transform.position, Quaternion.identity) as GameObject;
                Counter++;
            }
            transform.position += yOffset;
            xOffset = -xOffset;
        }
    }


    private void CameraMove()
    {
        mainCamera.transform.position += new Vector3(xOffset.x * (n - 1) / 2, (yOffset.y * (n - 1) / 2) - (n), mainCamera.transform.position.z);
        mainCamera.orthographicSize = xOffset.x * n + interval * (n - 1);
    }
    #endregion

}


