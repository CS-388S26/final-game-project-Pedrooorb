using UnityEngine;
using UnityEngine.EventSystems;

public class Level2Button : MonoBehaviour, IPointerClickHandler
{
    public GameManager gameManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        gameManager.LoadLevel2();
    }
}