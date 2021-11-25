using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GridManager gridManager;
    private int n;

    public Text inputText;
    public Text countText;

    private void Start()
    {
        gridManager = GameObject.Find("GridManager").GetComponent<GridManager>();
        n = PlayerPrefs.GetInt("GridNumber");
        inputText.text = n.ToString();
    }

    private void Update()
    {
        countText.text = "Match Count : " + gridManager.ScoreCounter;
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Rebuild();
        }
    }
    public void InputText(string input)
    {
        n = int.Parse(input);
        PlayerPrefs.SetInt("GridNumber", n);
    }
    public void Rebuild()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
