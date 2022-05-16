using UnityEngine;

public class CustomButton : MonoBehaviour
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
            if (_isRight) platformHub.Move(1);
            else platformHub.Move(-1);
        }
    }
    public void OnClick()
    {
        isPressed = !isPressed;
    }
}