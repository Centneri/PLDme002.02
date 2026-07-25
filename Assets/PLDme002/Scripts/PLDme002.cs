using UnityEngine;
using UnityEngine.InputSystem;

public class PLDme002 : MonoBehaviour
{


    private InputAction leftClickPressed;

    public GameObject so;
    [SerializeField]
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        leftClickPressed = new InputAction("LeftClick", binding: "<Mouse>/leftButton");


        leftClickPressed.performed += ctx => OnLeftClickExecuted();
    }

    private void OnEnable()
    {
        leftClickPressed.Enable();
    }

    private void OnDisable()
    {
        leftClickPressed.Disable();
    }

    private void OnLeftClickExecuted()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Debug.Log($"Left click executed at position: {mousePosition}");

        //if (mousePosition = spriteRenderer.bounds)
        //{
        //    Debug.Log("Mouse position is within the sprite renderer bounds.");
        //}
        //else
        //{
        //    Debug.Log("Mouse position is not within the sprite renderer bounds.");
        //}
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = so.GetComponent<SpriteRenderer>();

        //Vector3 rendererPosition = transform.position;

        //float posX = rendererPosition.x;
        //float posY = rendererPosition.y;
        //float posZ = rendererPosition.z;

        //Debug.Log($"Renderer Position - X: {posX}, Y: {posY}, Z: {posZ}");

        //if (spriteRenderer != null)
        //{
        //    positionFinderOR();
        //}
        //else
        //{
        //    Debug.Log("Sprite Renderer is null");
        //}
    }

    //void positionFinderOR()
    //{
    //    Bounds bounds = spriteRenderer.bounds;

    //    Vector2 center = bounds.center;
    //    Vector2 size = bounds.size;
    //    Vector2 min = bounds.min;
    //    Vector2 max = bounds.max;

    //    Debug.Log($"Sprite Renderer Bounds - Center: {center}, Size: {size}, Min: {min}, Max: {max}"); 
    //}
    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

            float radius = spriteRenderer.bounds.extents.x;
            float distance = Vector2.Distance(mouseWorldPos, (Vector2)transform.position);



            if (distance <= radius)
            {
                spriteRenderer.color = new Color(0, 1, 0); // Green
                Debug.Log("Mouse position is within the sprite renderer bounds. Turning green.");
            }
            else
            {
                spriteRenderer.color = new Color(1, 0, 0); // Red
                Debug.Log("Mouse position is not within the sprite renderer bounds. Turning red.");
            }



            //if (spriteRenderer.bounds.Contains(mouseWorldPos))
            //{
            //    spriteRenderer.color = new Color(0, 1, 0); // Green
            //}
            //else
            //{
            //    Debug.Log("Mouse position is not within the sprite renderer bounds.");
            //}

        }
    }
}
