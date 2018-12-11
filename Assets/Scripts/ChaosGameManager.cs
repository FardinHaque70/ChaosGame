using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosGameManager : MonoBehaviour
{
    [SerializeField] int numberOfPoints = 3;
    [SerializeField] GameObject pointPrefab;
    [SerializeField] bool start = false;
    [Space]
    [SerializeField] Transform[] pointsHolder = new Transform[3];
    [Space]
    [SerializeField] Transform[] trinaglePoints = new Transform[3];
    [SerializeField] Transform[] squarePoints = new Transform[4];
    [SerializeField] Transform[] hexagonPoints = new Transform[6];
    [Space]
        
    [SerializeField] Transform firstPoint;

    private Vector2 currentPointPosition = Vector2.zero;
    private float delay = 0.01f;
    int currentDiceNumber = 0;
    int lastDiceNumber = 0;
    GameObject holder;
    private float nextCall;
    private void Update()
    {
        if(start)
        {
            if (Time.time > nextCall)
            {
                nextCall = Time.time + delay;
                PlotPoint();
            }
        }
       
    }
    public void Calculate()
    {
        start = !start;
        currentPointPosition = firstPoint.position;
        GameObject g = new GameObject("Holder");
        //holder = Instantiate(pointPrefab, transform.position, Quaternion.identity);
        holder = g;
        holder.transform.localScale = Vector3.one;
        holder.name = "Holder";
    }

    void PlotPoint()
    {

        {
            if (numberOfPoints == 3)
            {
                currentDiceNumber = Random.Range(1, 7);
                //print(currentDiceNumber);
                if (currentDiceNumber == 1 || currentDiceNumber == 2)
                {
                    currentPointPosition = ((Vector2)trinaglePoints[0].position + currentPointPosition) / 2;
                }
                else if (currentDiceNumber == 3 || currentDiceNumber == 4)
                {
                    currentPointPosition = ((Vector2)trinaglePoints[1].position + currentPointPosition) / 2;
                }
                else if (currentDiceNumber == 5 || currentDiceNumber == 6)
                {
                    currentPointPosition = ((Vector2)trinaglePoints[2].position + currentPointPosition) / 2;
                }
                if (holder != null)
                    Instantiate(pointPrefab, currentPointPosition, Quaternion.identity, holder.transform);

            }
            //yield return new WaitForSeconds(0.005f);
            else if (numberOfPoints == 4)
            {
                currentDiceNumber = Random.Range(1, 5);
                if(lastDiceNumber == currentDiceNumber)
                {
                    print("Match");
                    return;
                }

                lastDiceNumber = currentDiceNumber;

                //print(currentDiceNumber);
                if (currentDiceNumber == 1)
                {
                    currentPointPosition = ((Vector2)squarePoints[0].position + currentPointPosition) / 2;
                }
                else if (currentDiceNumber == 2)
                {
                    currentPointPosition = ((Vector2)squarePoints[1].position + currentPointPosition) / 2;
                }
                else if (currentDiceNumber == 3)
                {
                    currentPointPosition = ((Vector2)squarePoints[2].position + currentPointPosition) / 2;
                }
                else if (currentDiceNumber == 4)
                {
                    currentPointPosition = ((Vector2)squarePoints[3].position + currentPointPosition) / 2;
                }
                if(holder != null)
                Instantiate(pointPrefab, currentPointPosition, Quaternion.identity, holder.transform);

            }
            else if (numberOfPoints == 6)
            {
                currentDiceNumber = Random.Range(1, 7);
                //print(currentDiceNumber);
                if (lastDiceNumber == currentDiceNumber)
                {
                    print("Match");
                    return;
                }
                lastDiceNumber = currentDiceNumber;


                if (currentDiceNumber == 1)
                {
                    currentPointPosition = ((Vector2)hexagonPoints[0].position + currentPointPosition) / 2;
                }
                else if (currentDiceNumber == 2)
                {
                    currentPointPosition = ((Vector2)hexagonPoints[1].position + currentPointPosition) / 2;
                }
                else if (currentDiceNumber == 3)
                {
                    currentPointPosition = ((Vector2)hexagonPoints[2].position + currentPointPosition) / 2;
                }
                else if (currentDiceNumber == 4)
                {
                    currentPointPosition = ((Vector2)hexagonPoints[3].position + currentPointPosition) / 2;
                }
                else if (currentDiceNumber == 5)
                {
                    currentPointPosition = ((Vector2)hexagonPoints[4].position + currentPointPosition) / 2;
                }
                else if (currentDiceNumber == 6)
                {
                    currentPointPosition = ((Vector2)hexagonPoints[5].position + currentPointPosition) / 2;
                }
                if (holder != null)
                    Instantiate(pointPrefab, currentPointPosition, Quaternion.identity, holder.transform);

            }
           // yield return new WaitForSecondsRealtime(delay);
        }
    }

    public void OnChangeNumber(int i)
    {
        Destroy(holder.gameObject);
        start = !start;

        if (i == 0)
            numberOfPoints = 3;
        else if (i == 1)
            numberOfPoints = 4;
        else if (i == 2)
            numberOfPoints = 6;
        if (numberOfPoints == 3)
        {
            pointsHolder[0].gameObject.SetActive(true);
            pointsHolder[1].gameObject.SetActive(false);
            pointsHolder[2].gameObject.SetActive(false);

        }
        if (numberOfPoints == 4)
        {
            pointsHolder[0].gameObject.SetActive(false);
            pointsHolder[1].gameObject.SetActive(true);
            pointsHolder[2].gameObject.SetActive(false);

        }
        if (numberOfPoints == 6)
        {
            pointsHolder[0].gameObject.SetActive(false);
            pointsHolder[1].gameObject.SetActive(false);
            pointsHolder[2].gameObject.SetActive(true);
        }
    }

    public void OnDelaySliderChange(float i)
    {
        delay = i;

    }
}
