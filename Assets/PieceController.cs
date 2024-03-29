using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieceController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int direction; // 0 - z=0, 1 - z=90, 2 - z=180, 3 - z=270
    private bool startMoving;
    [SerializeField] int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startMoving)
        { 
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y); 
        }
    }

    public void Init()
    {
        //direction = Random.Range(0, 4);
        //transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, 90 * direction);
        index = Random.Range(0, GamePlayController.Instance.GetMaxColor());
        Color[] col = GamePlayController.Instance.template;
        GetComponent<Image>().color = GamePlayController.Instance.template[index];
        GamePlayController.Instance.currentIndex.Add(index);
        startMoving = true;
    }

    public int GetDirection()
    {
        return direction;
    }

}
