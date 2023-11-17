using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HighlightAnItem : MonoBehaviour
{
   [SerializeField] private float _beamLength = 50f;
   [SerializeField] private GameObject[] _items;
   
   private InteractableItem _interactableItem;
   private Camera _camera;
   private void Awake()
   {
      _camera = Camera.main;
   }
   private void Update()
   {
     
      var ray = _camera.ScreenPointToRay(Input.mousePosition);
      Debug.DrawRay(transform.position,transform.forward*_beamLength,Color.green);
      
         if (Physics.Raycast(ray, out var info, _beamLength))
         {
            foreach (var item in _items)
            {
               _interactableItem = item.GetComponent<InteractableItem>();
               
               if (info.collider.name == item.name)
               {
                  _interactableItem.SetFocus();
               }
               else  
               {
                  _interactableItem.RemoveFocus();
               }
            }
         }
      
   }

   
}
