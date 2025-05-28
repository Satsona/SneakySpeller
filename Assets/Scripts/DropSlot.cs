using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;

        if (dropped != null)
        {
            Debug.Log("Dropped object: " + dropped.name + " onto " + gameObject.name);

            // Make the dropped letter a child of this slot
            dropped.transform.SetParent(transform);
        }
        else
        {
            Debug.LogWarning("DropSlot received null object.");
        }
    }
}
