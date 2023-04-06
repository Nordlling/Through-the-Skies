using System;
using UnityEngine;

public class DamagedObjectInfo
{
        public GameObject DamagedObject { get; set; }
        public int DamageAmount { get; set; }

        public DamagedObjectInfo(GameObject damagedObject, int damageAmount)
        {
            DamagedObject = damagedObject;
            DamageAmount = damageAmount;
        }
}
