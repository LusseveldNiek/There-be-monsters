using UnityEngine;

public class MonsterEscape : MonoBehaviour
{
    //added speed per frame
    public float escapeSpeed;
    private float beginEscapeSpeed;

    //distance atm
    private float currentDistance;

    //distance until escape
    public float maxDistance;

    //minimum distance
    public float minDistance;

    //gameover canvas
    public CanvasPositioning escapedCanvas;

    [Header("Freezing")]
    public float freezeTime;
    private float freezeCounter;

    public float freezeSpeed;

    public bool isFrozen;
    public Material normalMaterial;

    private void Start()
    {
        //enemy begins with minDistance
        currentDistance = minDistance;
        beginEscapeSpeed = escapeSpeed;
    }

    void Update()
    {
        //set distance
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, currentDistance);

        if(currentDistance < maxDistance)
        {
            //add escape speed
            currentDistance += escapeSpeed * Time.deltaTime;
        }


        //escape
        if(currentDistance > maxDistance)
        {
            print("you lost");
            escapedCanvas.activateCanvas = true;
            Time.timeScale = 0;
        }

        if(isFrozen)
        {
            escapeSpeed = 0;
            freezeCounter += Time.deltaTime;
            if(currentDistance > minDistance)
            {
                currentDistance -= freezeSpeed * Time.deltaTime;
            }

            if(freezeCounter > freezeTime)
            {
                GetComponent<MeshRenderer>().material = normalMaterial;
                freezeCounter = 0;
                isFrozen = false;
                escapeSpeed = beginEscapeSpeed;
            }
        }
    }
}
