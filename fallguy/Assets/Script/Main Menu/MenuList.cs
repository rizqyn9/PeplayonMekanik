using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuList : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public MenuGroup menuGroup;
    public Image image;

    public void OnPointerClick(PointerEventData eventData)
    {
        menuGroup.OnListSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        menuGroup.OnListEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        menuGroup.OnListExit(this);
        menuGroup.animOnPointerExit();
    }

    private void Start()
    {
        menuGroup.Subscribe(this);
    }
}