using UnityEngine;

public class MoveToLeftOnStart : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject wall;
    void Update()
    {
        Vector3 leftside = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        wall.transform.position = new Vector3(mainCamera.transform.position.x - leftside.x, wall.transform.position.y, 10);
    }

}
