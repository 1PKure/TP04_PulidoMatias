using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class UISettings : MonoBehaviour
{
    [Header("SliderPanel")]
    [SerializeField] private Slider player1SpeedSlider;
    [SerializeField] private Slider player2SpeedSlider;
    //[SerializeField] private Slider paddleHeightSlider;
    //[SerializeField] private Image playerColorImage;
    [Header("UIText")]
    [SerializeField] private TextMeshProUGUI player1SpeedText;
    [SerializeField] private TextMeshProUGUI player2SpeedText;
    [Header("PlayerMovement")]
    [SerializeField] private PlayerController player1movement;
    [SerializeField] private PlayerController player2movement;


    private void Awake()
    {
        player1SpeedSlider.onValueChanged.AddListener(SetPlayer1Speed);
        player2SpeedSlider.onValueChanged.AddListener(SetPlayer2Speed);
        //paddleHeightSlider.value = player1movement.transform.localScale.y;


    }

    private void OnDestroy()
    {

        player1SpeedSlider.onValueChanged.RemoveListener(SetPlayer1Speed);
        player2SpeedSlider.onValueChanged.RemoveListener(SetPlayer2Speed);


    }

    /*
    public void OnPaddleHeightChanged()
    {
        // Cambiar el alto de las paletas
        Vector3 newScale = new Vector3(player1movement.transform.localScale.x, paddleHeightSlider.value, player1movement.transform.localScale.z);
        player1movement.transform.localScale = newScale;
        player2movement.transform.localScale = newScale;
    }
    */
    public void SetPlayer1Speed(float speed)
    {
        player1movement.SetMovementSpeed(speed);
        player1SpeedText.text = speed.ToString("F2");
    }

    public void SetPlayer2Speed(float speed)
    {
        player2movement.SetMovementSpeed(speed);
        player2SpeedText.text = speed.ToString("F2");
    }
}

