using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    [SerializeField] private GameObject girlPlayer;
    [SerializeField] private GameObject boyPlayer;

    [SerializeField] private Transform boySideMovementRoot;
    [SerializeField] private Transform girlSideMovementRoot;

    [SerializeField] private Transform boyLeftLimit;
    [SerializeField] private Transform boyRightLimit;

    [SerializeField] private Transform girlLeftLimit;
    [SerializeField] private Transform girlRightLimit;

    private float speed => SettingsManager.GameSettings.playersSpeed;
    private float sideMovementSensitivity => SettingsManager.GameSettings.playersSideMovementSensitivity;


    private Vector2 inputDrag;

    private Vector2 previousMousePosition;

    private float boyLeftLimitX => boyLeftLimit.localPosition.x;
    private float boyRightLimitX => boyRightLimit.localPosition.x;

    private float girlLeftLimitX => girlLeftLimit.localPosition.x;
    private float girlRightLimitX => girlRightLimit.localPosition.x;

    private const float startGirlForwardDistance = 1.5f;
    private const float centerForGirl = 1.14f;
    private bool isFinish;

    private void Awake()
    {
        isFinish = false;
        DistanceFinder.allDistance += ChangeGirlZPosition;
        BoyPlayer.finish += ChangeFinishBool;
    }

    private void OnDestroy()
    {
        DistanceFinder.allDistance -= ChangeGirlZPosition;
        BoyPlayer.finish -= ChangeFinishBool;
    }

    void Update()
    {
        HandleInput();
        SideMovement();
        if (!isFinish)
        {
            ForwardMovement();
        }
        
    }

    private void ForwardMovement()
    {
        BoyForwardMovement();
        GirlForwardMovement();
    }

    private void BoyForwardMovement()
    {
        boyPlayer.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void GirlForwardMovement()
    {
        girlPlayer.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void SideMovement()
    {
        BoySideMovement();
        GirlSideMovement();
    }

    private void BoySideMovement()
    {
        var localPosBoy = boySideMovementRoot.localPosition;
        localPosBoy += Vector3.right * inputDrag.x * sideMovementSensitivity;
        localPosBoy.x = Mathf.Clamp(localPosBoy.x, boyLeftLimitX, boyRightLimitX);
        boySideMovementRoot.localPosition = localPosBoy;
    }

    private void GirlSideMovement()
    {
        var localPosGirl = girlSideMovementRoot.localPosition;
        localPosGirl -= Vector3.right * inputDrag.x * sideMovementSensitivity;
        localPosGirl.x = Mathf.Clamp(localPosGirl.x, girlLeftLimitX, girlRightLimitX);
        girlSideMovementRoot.localPosition = localPosGirl;
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.IsGameStartEnable();
            previousMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            var deltaMouse = (Vector2) Input.mousePosition - previousMousePosition;
            inputDrag = deltaMouse;
            previousMousePosition = Input.mousePosition;
        }
        else
        {
            inputDrag = Vector2.zero;
        }
    }

    private void ChangeGirlZPosition(float distanceX)
    {
        var difference = startGirlForwardDistance - distanceX;
        var girlLocal = girlSideMovementRoot.localPosition;
        var boyLocalZ = boySideMovementRoot.localPosition.z;
        var zForward = boyLocalZ + difference;

        if (girlLocal.z < zForward) //if she has closedistance we are increasing her z positioning. 
        {
            girlLocal.z += 2f * Time.deltaTime;
        }
        else if
            (girlLocal.z > boyLocalZ &&
             (centerForGirl >= distanceX ||
              centerForGirl <= distanceX)) // if she at forward and their distance bigger than girls center position.
        {
            girlLocal.z -= 2f * Time.deltaTime;
        }

        girlSideMovementRoot.localPosition = girlLocal;
    }

    private void ChangeFinishBool()
    {
        girlPlayer.SetActive(false);
        boyPlayer.SetActive(false);
        isFinish = true;
    }
}