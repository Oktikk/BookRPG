using UnityEngine;
using Cinemachine;

public class RoundCameraPos : CinemachineExtension
{
    public float PixelsPerUnit = 32;


    // Metoda wywo³ywana przez Cinemachine gdy Confiner zakoñczy realizacjê swojego procesu

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        // Sprawdzenie bie¿¹cego etapu koñcowego przetwarzania
        if (stage == CinemachineCore.Stage.Body)
        {
            // Uzyskanie koñcowej pozycji kamery wirtualnej
            Vector3 finalPos = state.FinalPosition;

            // Wywo³anie metody zaokr¹glaj¹cej pozycjê
            Vector3 newPos = new Vector3(Round(finalPos.x), Round(finalPos.y), finalPos.z);
            // Ustawienie nowej pozycji kamery wirtualnej na ró¿nicê miêdzy  
            // poprzedni¹ pozycj¹ a now¹ zaokr¹glon¹, wyliczon¹ wy¿ej.
            state.PositionCorrection += newPos - finalPos;
        }
    }

    float Round(float x)
    {
        return Mathf.Round(x * PixelsPerUnit) / PixelsPerUnit;
    }
}