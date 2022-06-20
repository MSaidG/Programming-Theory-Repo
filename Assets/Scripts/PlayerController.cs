using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public GameObject ball;
    public Camera cameraMain;
    public Slider forceSlider;

    private float throwForce = 1000;

    private float holdDownButtonStartTime;
    private float holdDownButtonFinishTime;

    private float sliderFill = 0;
    private float runTime = 2f;

    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        forceSlider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1 && !EventSystem.current.IsPointerOverGameObject())
        {
            

            if (Input.GetMouseButtonDown(0) && !isPaused)
            {

                forceSlider.value = forceSlider.minValue;
                holdDownButtonStartTime = Time.time;
            }

            if (Input.GetMouseButton(0) && !isPaused)
            {
                FillBar();
            }

            if (Input.GetMouseButtonUp(0) && !isPaused)
            {
                ResetSliderBar();
                holdDownButtonFinishTime = Time.time;
                ThrowBall(holdDownButtonFinishTime - holdDownButtonStartTime);
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                PauseAndRestarTheGame();
            }
        }
    }

    void ThrowBall(float holdDownButtonTime)
    {
        Ray r = cameraMain.ScreenPointToRay(Input.mousePosition);
        Vector3 direction = r.GetPoint(1) - r.GetPoint(0);
        GameObject projectile = Instantiate(ball, r.GetPoint(2), Quaternion.LookRotation(direction));

        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * throwForce * holdDownButtonTime);
    }

    void FillBar()
    {
        forceSlider.gameObject.SetActive(true);
        sliderFill += Time.deltaTime;
        forceSlider.value = Mathf.Lerp(0, 1, sliderFill / runTime);
    }

    void ResetSliderBar()
    {
        sliderFill = 0;
        forceSlider.value = 0;
        forceSlider.gameObject.SetActive(false);
    }

    private void PauseAndRestarTheGame()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else if (!isPaused)
        {
            Time.timeScale = 1;
        }
    }
}
