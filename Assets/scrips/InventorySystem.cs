using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public Transform inventoryContent; // Contenedor del inventario donde se a�aden los objetos

    // Este m�todo podr�a servir si quieres a�adir objetos de otra manera o con l�gica adicional.
    public void AddItemToInventory(GameObject item)
    {
        GameObject itemClone = Instantiate(item); // Crear una copia del objeto
        itemClone.transform.SetParent(inventoryContent); // Mover al panel del inventario
        itemClone.transform.localScale = Vector3.one; // Ajustar escala en el inventario
    }
}
