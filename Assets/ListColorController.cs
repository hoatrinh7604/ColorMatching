using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListColorController : MonoBehaviour
{
    [SerializeField] Image[] list;

    // Start is called before the first frame update
    void Start()
    {
        ShowList(GamePlayController.Instance.GetMaxColor());
    }

    private void ShowList(int max)
    {
        for(int i = 0; i < GamePlayController.Instance.template.Length; i++)
        {
            list[i].color = GamePlayController.Instance.template[i];
            list[i].gameObject.SetActive(i < max);
        }
    }
}
