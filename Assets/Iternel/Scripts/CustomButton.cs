using UnityEngine;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private bool _isRight;
    private PlatformHub platformHub;
    private bool isPressed = false; 
         
    private void Start()
    {
        platformHub = GameObject.Find("MovingPlatforms").GetComponent <PlatformHub>();
    }
    private void Update()
    {
        if (isPressed)
        {
            UIController.Instance.ButtonPressed (_isRight);
        }
    }

    public void OnPointerDown (PointerEventData eventData) {
        Debug.Log ("down!");
        isPressed = true;
    }

    public void OnPointerUp (PointerEventData eventData) {
        isPressed = false;
    }
}