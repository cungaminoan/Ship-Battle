using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBound2 : MonoBehaviour
{
    public Camera MainCamera;
    private Vector2 screenBounds;
    private float shipWidth;
    private float shipHeight;
    [SerializeField] private GameObject Ship;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        shipWidth = Ship.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        shipHeight = Ship.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + shipWidth, screenBounds.x - shipWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + shipHeight, screenBounds.y - shipHeight);
        transform.position = viewPos;
    }
}
