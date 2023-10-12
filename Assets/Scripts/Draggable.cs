using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Camera Camera;
    public Image Image;
    [HideInInspector] public Transform parent;
    public static Draggable DraggableDragging;

    private void OnValidate()
    {
        Image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("On beggin");
        parent = transform.parent;
        transform.parent = transform.root;
        this.Image.raycastTarget = false;
        DraggableDragging = this;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("on Drag");
        var worldPositon = this.Camera.ScreenToWorldPoint(Input.mousePosition);
        worldPositon.z = 0;
        transform.position = worldPositon;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("on End Drag");
        transform.SetParent(parent);
        this.Image.raycastTarget = true;
        DraggableDragging = null;
    }
}