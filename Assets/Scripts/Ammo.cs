using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;//Serialize this and shows it in the inspector

    [System.Serializable] // it shows the content that belongs to this class all in the inspector
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType)  // needs to know what type of ammo we have to reduce so passing ammotype 
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount+=ammoAmount;    //incerementing the amount of ammo when we pickup
    }
    public int ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)  // by this we can know which ammoslot matches the ammotype
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)  //ammotype in scene matches with ammotype we passed
            {
                return slot;
            }
        }
        return null;// in case we doesn't return anything in loop
    }

}
