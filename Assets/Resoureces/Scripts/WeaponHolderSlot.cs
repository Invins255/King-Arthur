using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolderSlot : MonoBehaviour
{
    public Transform ParentOverride;

    public bool IsLeftHandSlot;
    public bool IsRightHandSlot;

    public GameObject CurrentWeaponModel;

    public void LoadWeaponModel(WeaponItem weaponItem)
    {
        UnloadWeaponModelAndDestroy();

        if (weaponItem == null)
        {
            UnloadWeaponModel();
            return;
        }

        GameObject model = Instantiate(weaponItem.ModelPrefab);
        if(model != null)
        {
            if(ParentOverride != null)
                model.transform.parent = ParentOverride.transform;
            else
                model.transform.parent = transform;

            model.transform.localPosition = Vector3.zero;
            model.transform.localRotation = Quaternion.identity;
            model.transform.localScale = Vector3.one;
        }

        CurrentWeaponModel = model;
    }

    public void UnloadWeaponModel()
    {
        if (CurrentWeaponModel != null)
            CurrentWeaponModel.SetActive(false);
    }

    public void UnloadWeaponModelAndDestroy()
    {
        if (CurrentWeaponModel != null)
            Destroy(CurrentWeaponModel);
    }
}
