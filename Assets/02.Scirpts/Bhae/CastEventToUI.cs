using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;
using Valve.VR.Extras;


public class CastEventToUI : MonoBehaviour
{
   private SteamVR_LaserPointer laserPointer;

   void  OnEnable()
   {
       laserPointer = gameObject.GetComponent<SteamVR_LaserPointer>();

       // 이벤트 할당
       laserPointer.PointerIn   += OnPointerEnter;
       laserPointer.PointerOut += OnPointerExit;
       laserPointer.PointerClick += OnPhointerClick;
   }

   void OnDisable()
   {
       laserPointer.PointerIn   -= OnPointerEnter;
       laserPointer.PointerOut -= OnPointerExit;
       laserPointer.PointerClick -= OnPhointerClick;
   }

   void OnPointerEnter(object sender, PointerEventArgs e)
   {
       IPointerEnterHandler enterHandler = e.target.GetComponent<IPointerEnterHandler>();
       if (enterHandler == null) return;

       enterHandler.OnPointerEnter(new PointerEventData(EventSystem.current));
   }

   void OnPointerExit(object sender, PointerEventArgs e)
   {
       IPointerExitHandler exitHandler = e.target.GetComponent<IPointerExitHandler>();
       if (exitHandler == null) return;

       exitHandler.OnPointerExit(new PointerEventData(EventSystem.current));
   }

   void OnPhointerClick(object sender, PointerEventArgs e)
   {
       IPointerClickHandler clickHandler = e.target.GetComponent<IPointerClickHandler>();
       if (clickHandler == null) return;

       clickHandler.OnPointerClick(new PointerEventData(EventSystem.current));
   }
}
