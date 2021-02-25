using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlocksCounter : MonoBehaviour
{
    public GameObject BlocksCounterUI;
    public Text dodgedBlocks;
    public Text counter;
    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        counter.text = "0";
        BlocksCounterUI.SetActive(true);
        FallingBlockScript.OnBlockDestroy += Count;
        FindObjectOfType<PlayerController>().OnPlayerDeath += OnPlayerDeath;
    }

    void Count()
    {
        if (!isDead)
        {
            counter.text = (int.Parse(counter.text) + 1).ToString();
        }
    }

    void OnPlayerDeath()
    {
        isDead = true;
    }
}
