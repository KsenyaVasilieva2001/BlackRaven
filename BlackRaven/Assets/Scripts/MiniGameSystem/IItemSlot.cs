using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * интерфейс для объектов, куда можно сложить предметы (ступка и тарелки)
 */
public interface IItemSlot
{
    bool CanAccept();
    void Accept(GameObject itemInstance);
}
