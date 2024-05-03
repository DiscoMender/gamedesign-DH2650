using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIContentCarousel : MonoBehaviour
{
    public GameObject scrollbar;
    float scroll_pos = 0f;
    float[] pos;

    private void Start()
    {
        scrollbar.GetComponent<Scrollbar>().value = scroll_pos;
    }

    private void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i =0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance/2) && scroll_pos> pos[i] - (distance / 2)){
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }
    }
}
