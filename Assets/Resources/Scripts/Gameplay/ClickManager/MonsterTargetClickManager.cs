using Assets.Scripts.Gameplay.Units;
using UnityEngine;

public class MonsterTargetClickManager : MonoBehaviour
{
    [SerializeField]
    private GameObject selectedPrefab;

    private GameObject selectionMarker;

    public static GameObject SelectedMonster = null;

    private void Update()
    {
        // On mouse click
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                // Get the first collider of the clicked gameobject
                Collider2D firstCollider = hit.collider.gameObject.GetComponents<Collider2D>()[0];

                // If the hit collider is the first collider and it belongs to a monster
                if (firstCollider != null && hit.collider.gameObject.GetComponent<Attacker>() != null)
                {
                    // Deactivate animation on previous selected monster, if any
                    if (SelectedMonster != null && SelectedMonster.GetComponent<Attacker>() != null)
                    {
                        DeselectSelection(); // call to deselect previous monster
                    }

                    // Set new selected monster
                    SelectedMonster = hit.collider.gameObject;
                    Debug.Log("Currently selected :" + SelectedMonster.name);

                    MarkSelection(); // call to mark new selected monster
                }
            }
        }
    }

    public void MarkSelection()
    {
        // Create a selection marker at the SelectedMonster's position
        if (SelectedMonster != null)
        {
            selectionMarker = Instantiate(selectedPrefab, SelectedMonster.transform.position, Quaternion.identity);
            selectionMarker.transform.parent = SelectedMonster.transform;
            selectionMarker.name = "SelectionMarker"; // Setting a unique name
        }
    }

    public void DeselectSelection()
    {
        // Remove the selection marker, if it exists
        if (selectionMarker != null)
        {
            Destroy(selectionMarker);
        }
    }
}
