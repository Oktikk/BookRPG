using UnityEngine;
using Cinemachine;

public class RoundCameraPos : CinemachineExtension
{
    public float PixelsPerUnit = 32;


    // Metoda wywo�ywana przez Cinemachine gdy Confiner zako�czy realizacj� swojego procesu

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        // Sprawdzenie bie��cego etapu ko�cowego przetwarzania
        if (stage == CinemachineCore.Stage.Body)
        {
            // Uzyskanie ko�cowej pozycji kamery wirtualnej
            Vector3 finalPos = state.FinalPosition;

            // Wywo�anie metody zaokr�glaj�cej pozycj�
            Vector3 newPos = new Vector3(Round(finalPos.x), Round(finalPos.y), finalPos.z);
            // Ustawienie nowej pozycji kamery wirtualnej na r�nic� mi�dzy  
            // poprzedni� pozycj� a now� zaokr�glon�, wyliczon� wy�ej.
            state.PositionCorrection += newPos - finalPos;
        }
    }

    float Round(float x)
    {
        return Mathf.Round(x * PixelsPerUnit) / PixelsPerUnit;
    }
}