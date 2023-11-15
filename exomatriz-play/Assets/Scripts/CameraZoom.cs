using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float zoomSpeed = 1.0f;
    public float minOrthoSize = 2f;
    public float maxOrthoSize = 10f;

    private void Update()
    {
        // Check if the virtual camera is assigned
        if (virtualCamera == null)
        {
            Debug.LogWarning("Cinemachine Virtual Camera not assigned.");
            return;
        }

        // Get the mouse scroll input
        float scrollValue = Mouse.current.scroll.ReadValue().y;

        // Update the orthographic size based on the scroll input
        float newSize = virtualCamera.m_Lens.OrthographicSize - scrollValue * zoomSpeed * Time.deltaTime;
        newSize = Mathf.Clamp(newSize, minOrthoSize, maxOrthoSize);

        // Apply the new orthographic size to the virtual camera
        virtualCamera.m_Lens.OrthographicSize = newSize;
    }
}