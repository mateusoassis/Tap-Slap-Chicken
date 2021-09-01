using UnityEngine;
 using UnityEngine.EventSystems;
 using System.Collections;
 
 public class UIHover : MonoBehaviour
 {
     public bool isUIMouseOver { get; private set; }
 
     void Update()
     {
         // It will turn true if hovering any UI Elements
         isUIMouseOver = EventSystem.current.IsPointerOverGameObject ();
     }
 }
