using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockController : MonoBehaviour
{
    public int blockCount = 0;
    public static BlockController instance;
    public GameObject WinPopUp;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        blockCount = gameObject.transform.childCount;
    }

    public void ActiveWinPopUp()
    {
        Time.timeScale = 0;
        WinPopUp.SetActive(true);
    }

    public void ReplayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");

    }
}
