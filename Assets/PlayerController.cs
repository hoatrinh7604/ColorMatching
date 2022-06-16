using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int currentDir;
    [SerializeField] GameObject effect;

    [SerializeField] int currentColorIndex;
    private int maxColor;
    private Color[] color;
    // Start is called before the first frame update
    void Start()
    {
        color = GamePlayController.Instance.template;
        currentDir = 0;
        maxColor = GamePlayController.Instance.GetMaxColor();
        currentColorIndex = Random.Range(0, maxColor);
        UpdateColor();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ChangeColor();
        }
    }

    public void ChangeDirection()
    {
        currentDir++;
        if (currentDir > 3) currentDir = 0;

        transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, 90 * currentDir);
        Color[] col = GamePlayController.Instance.template;
        GetComponent<Image>().color = GamePlayController.Instance.template[Random.Range(0, col.Length)];
    }

    private void UpdateColor()
    {
        GetComponent<Image>().color = color[currentColorIndex];
    }

    public void ChangeColor()
    {
        currentColorIndex++;
        if(currentColorIndex >= maxColor) currentColorIndex = 0;

        UpdateColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Piece")
        {
            if (currentColorIndex == GamePlayController.Instance.currentIndex[0])
            {
                GamePlayController.Instance.currentIndex.RemoveAt(0);
                SpawEffect();
                GamePlayController.Instance.UpdateScore();
                Destroy(collision.gameObject);
            }
            else
            {
                // Game over
                Destroy(collision.gameObject);
                GamePlayController.Instance.GameOver();
            }
        }
    }

    public void SpawEffect()
    {
        GameObject eff = Instantiate(effect, Vector2.zero, Quaternion.identity);
        eff.transform.SetParent(transform);
        eff.transform.position = transform.position;
        eff.transform.localPosition = Vector3.zero;
        eff.transform.localScale = Vector3.one;
        Destroy(eff, 0.5f);
    }
}
