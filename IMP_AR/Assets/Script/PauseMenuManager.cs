using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuManager : MonoBehaviour
{


    public GameObject pauseUI;


    private bool isPause = false;


    // Update is called once per frame
    void Update()
    {
        if (IsPointerOverUIElement()) return;
    }


    public void Pause()
    {
        if (isPause == true)
        {
            Time.timeScale = 1;
            Debug.Log("is played");
            pauseUI.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            Debug.Log("is paused");
            pauseUI.SetActive(true);
        }

        isPause = !isPause;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public static bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }

    ///Returns 'true' if we touched or hovering on Unity UI element.
    public static bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == LayerMask.NameToLayer("UI"))
                return true;
        }
        return false;
    }

    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }
}
