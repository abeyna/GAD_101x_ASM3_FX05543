using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Block : MonoBehaviour
{
    public GameObject boomExplore;
    public TextMeshPro textHP;
    public float blockHP = 99;
    public float fallingSpeed = 3.0f;
   

    float timer;


    // Start is called before the first frame update
    void Start()
    {

        fallingSpeed = Random.Range(1.0f, 3.0f);
        textHP.text = blockHP.ToString();
        timer = fallingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.1f);
            timer = fallingSpeed;
        }
    }

    public void OnDamaged(float damage)
    {
        if(blockHP > 0)
            blockHP -= damage;
        textHP.text = blockHP.ToString();
        if (blockHP <= 0)
        {
            Destroy(gameObject);
            Vector2 exploreLocation = boomExplore.transform.position;
            Instantiate(boomExplore, exploreLocation, Quaternion.identity);
            BlockController.instance.blockCount--;
            if(BlockController.instance.blockCount <= 0)
            {
                BlockController.instance.ActiveWinPopUp();
            }
        }

        
    }
}
