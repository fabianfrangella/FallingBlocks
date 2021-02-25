using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlockScript : MonoBehaviour
{
    public Vector2 speedMinMax;
    public static event System.Action OnBlockDestroy;
    float speed;

    float visibleHeightThreshold;
    // Start is called before the first frame update
    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());

        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < visibleHeightThreshold)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if(OnBlockDestroy!= null)
        {
            OnBlockDestroy();
        }
    }
}
