using Assets.Scripts.Gameplay.Units;
using UnityEngine;

public class MonsterTargetClickManager : MonoBehaviour
{
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
                        //SelectedMonster.GetComponent<Attacker>().selectedAnimation.SetActive(false);
                    }

                    // Set new selected monster
                    SelectedMonster = hit.collider.gameObject;
                    Debug.Log("Currently selecte :" + SelectedMonster.name);
                    // Activate animation on new selected monster
                    //SelectedMonster.GetComponent<Attacker>().selectedAnimation.SetActive(true);
                }
            }
        }
    }
}
