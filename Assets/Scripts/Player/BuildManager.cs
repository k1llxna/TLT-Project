using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject heldUnit;

    [SerializeField] private Event currentEvent;
    [SerializeField] private Hex storedHex; // origin of pickup
    [SerializeField] private Transform pickUpPos;
    [SerializeField] private Camera mainCamera;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {
        NullComponents();
    }

    #region mouse 
    // check and pick up a unit
    public IEnumerator MouseDown()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)) // first instance to pick up only execute if hex
        {
            if (hit.transform.gameObject.CompareTag("Hex"))
            {
                if (hit.transform.gameObject.GetComponent<Hex>().GetIsOccupied() == true)
                    {// pick up here
                        pickUpPos = hit.transform.gameObject.GetComponent<Hex>().GetHeldUnit().transform;
                        // register unit being held
                        heldUnit = hit.transform.gameObject.GetComponent<Hex>().GetHeldUnit();
                        // store unit
                        storedHex = hit.transform.gameObject.GetComponent<Hex>();

                        //shop ehre
                        Shop.instance.ToggleShop(false);
                        Shop.instance.ToggleSell(true);
                }
                
            }
            // continuos update of unit to cursor
            if (heldUnit != null & hit.transform.gameObject.CompareTag("Hex"))
            {
                while (!Input.GetMouseButtonUp(0)) // while mouse is down lol
                {
                    // update the ray for the cursor snapping
                    ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hit_))
                    {
                        if (heldUnit)
                             pickUpPos.position = hit_.point;                       
                    }
                    yield return null;
                }
            }
        }       
    }

    public IEnumerator MouseUp() // assumption that a unit is being held
    {
        Shop.instance.ToggleShop(true);
        Shop.instance.ToggleSell(false);

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)) 
        {
            if (hit.transform.gameObject.CompareTag("Hex")) // check if its a hex
            {
                Hex newHex = hit.transform.gameObject.GetComponent<Hex>();
                
                if (newHex.GetIsOccupied() == false)
                { // place on new hex
                    heldUnit.GetComponent<UnitMovement>().MoveToNewHex(storedHex, newHex);
                }
                else if (newHex.GetIsOccupied() == true)
                {
                    heldUnit.GetComponent<UnitMovement>().SwapHex(storedHex, newHex);
                }
                NullComponents();           
            }
            // sell unit
            else if (EventSystem.current.IsPointerOverGameObject())
            {
                PlayerStats.instance.SetGold(heldUnit.gameObject.GetComponent<Unit>().sellCost);

                if (heldUnit.gameObject.GetComponent<UnitMovement>().originHex.gameObject.GetComponent<Hex>().GetIsBenchHex() == false)
                { // board to bench counter update
                    PlayerStats.instance.SetBoardCounter(-1);
                }
                else
                {
                    PlayerStats.instance.SetBenchCounter(-1);
                }
                PlayerStats.instance.SetSupply(-1);

                // remove held unit from its held hex
                heldUnit.gameObject.GetComponent<UnitMovement>().originHex.gameObject.GetComponent<Hex>().SetHeldUnit(null);

                // toggle hex occupancy
                heldUnit.gameObject.GetComponent<UnitMovement>().originHex.gameObject.GetComponent<Hex>().SetIsOccupied(false);

                // update tier (for 3* units later on)
                PlayerStats.instance.TierTracker(heldUnit.gameObject.GetComponent<Unit>().tier, -1);

                NullComponents();
                Debug.Log("Sold Unit!");
            }
            else
            { // return unit to origin hex
                ResetPos();
                //NullComponents();
            }
        }
        yield return null;
    }
    #endregion

    #region util
    public Hex GetStoredHex() { return storedHex; }

    public void ResetPos()
    {
        pickUpPos.position = storedHex.gameObject.transform.position;
        NullComponents();
    }

    private void NullComponents()
    {
        pickUpPos = null;
        storedHex = null;
        heldUnit = null;
    }
    #endregion
}
