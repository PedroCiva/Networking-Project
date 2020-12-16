using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PointsHandler : NetworkBehaviour
{
    private GameObject LeftPlayerPoints;
    private GameObject RightPlayerPoints;

    [SyncVar]
    public int pointsLeft;
    [SyncVar]
    public int pointsRight;

    [ClientRpc]
    public void RpcIncreasePointsLeft()
    {
        pointsLeft++;
    }
    [ClientRpc]
    public void RpcIncreasePointsRight()
    {
        pointsRight++;
    }
    public int GetPointsLeft()
    {
        return pointsLeft;
    }
    public int GetPointsRight()
    {
        return pointsRight;
    }



    // Start is called before the first frame update
    void Start()
    {
        pointsLeft = 0;
        pointsRight = 0;

        LeftPlayerPoints = GameObject.Find("LeftPlayerPoints");
        LeftPlayerPoints.GetComponent<Text>().text = pointsLeft.ToString();

        RightPlayerPoints = GameObject.Find("RightPlayerPoints");
        RightPlayerPoints.GetComponent<Text>().text = pointsRight.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        LeftPlayerPoints.GetComponent<Text>().text = pointsLeft.ToString();

        RightPlayerPoints.GetComponent<Text>().text = pointsRight.ToString();
    }
}
