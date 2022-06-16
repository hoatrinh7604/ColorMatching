using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawObject : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject piece;
    [SerializeField] float timeDelay;
    private int times;
    private float time;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > timeDelay)
        {
            time = 0;
            Spaw();

            times++;
            if(times > 5)
            {
                timeDelay -= 0.5f;
                if (timeDelay < 1.5f) timeDelay = 1.5f;
                times = 0;
            }
        }
    }

    public void Spaw()
    {
        GameObject obj = Instantiate(piece, Vector2.zero, Quaternion.identity);
        obj.transform.SetParent(transform);
        obj.transform.localPosition = Vector2.zero;
        obj.transform.localScale = Vector3.one;
        obj.GetComponent<PieceController>().Init();
    }
}
