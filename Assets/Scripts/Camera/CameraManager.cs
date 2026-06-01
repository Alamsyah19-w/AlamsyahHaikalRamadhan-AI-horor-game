using UnityEngine;
using Unity.Cinemachine;
public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachinePanTilt panTilt;
    [SerializeField] private CinemachineInputAxisController cameraInputController;

    public float panAxis => panTilt.PanAxis.Value;

    public void SetCameraInput(bool isActive)
    {
        cameraInputController.enabled = isActive;
    }
    public void ResetCameraRotation()
    {
        panTilt.PanAxis.Value = 0f;
        panTilt.TiltAxis.Value = 0f;
    }
    public void SetPanAxisValue(float panValue)
    {
        panTilt.PanAxis.Value = panValue;
    }
    public void SetTiltAxisValue(float tiltValue)
    {
        panTilt.TiltAxis.Value = tiltValue;
    }
}
