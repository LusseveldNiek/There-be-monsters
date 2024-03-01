using UnityEngine;

public class MonsterEscape : MonoBehaviour
{
    //added speed per frame
    public float escapeSpeed;

    private float currentDistance;

    //distance until escape
    public float maxDistance;
    //minimum distance
    public float minDistance;

    private void Start()
    {
        //enemy begins with minDistance
        currentDistance = minDistance;
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
        }
    }
}
