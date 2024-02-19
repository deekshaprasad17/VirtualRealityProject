using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class cutscene : MonoBehaviour
{
    public CinemachineVirtualCamera cutsceneCamera;
    public PlayableDirector cutsceneDirector;

    void Start()
    {
        // Disable player control during the cutscene
        // For example, you could disable the player's VR controllers

        // Activate the cutscene camera
        if (cutsceneCamera != null)
        {
            cutsceneCamera.Priority = 100; // Set a high priority to ensure it's active
        }

        // Play the cutscene timeline
        if (cutsceneDirector != null)
        {
            StartCoroutine(PlayCutscene());
        }
    }

    IEnumerator PlayCutscene()
    {
        // Wait for a short delay before starting the cutscene
        yield return new WaitForSeconds(1.0f);

        // Play the cutscene
        cutsceneDirector.Play();

        // Wait for the cutscene to finish
        while (cutsceneDirector.state == PlayState.Playing)
        {
            yield return null;
        }

        // Once the cutscene is finished, deactivate the cutscene camera
        if (cutsceneCamera != null)
        {
            cutsceneCamera.Priority = 0; // Set a lower priority to deactivate it
        }

        // Re-enable player control after the cutscene
        // For example, you could re-enable the player's VR controllers
    }
}
