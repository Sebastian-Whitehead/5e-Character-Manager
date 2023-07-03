using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
   public enum PosType
   {
      Drift,
      Shifting,
      FixedBot
   }

   public PosType placement;
   
   public TextMeshProUGUI headerField;
   public TextMeshProUGUI contentField;
   public LayoutElement layoutElement;

   public int characterWrapLimit;

   public RectTransform rectTransform;

   private void Awake()
   {
      rectTransform = GetComponent<RectTransform>();
   }

   public void SetText(string content, string header = "")
   {
      if (string.IsNullOrEmpty(header))
      {
         headerField.gameObject.SetActive(false);
      }
      else
      {
         headerField.gameObject.SetActive(true);
         headerField.text = header;
      }

      contentField.text = content;
      UpdateSize();
   }

   private void UpdateSize()
   {
      int headerLength = headerField.text.Length;
      int contentLength = contentField.text.Length;

      layoutElement.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
   }
   
   private void Update()
   {
      if (Application.isEditor) UpdateSize();

      Vector2 position = Input.mousePosition;

      float pivotX = 0.5f;
      float pivotY = 0.5f;

      switch (placement)
      {
         case PosType.Drift:
            pivotX = position.x / Screen.width;
            pivotY = position.y / Screen.height;
            break;
         
         case PosType.Shifting:
            pivotX = 0f;
            pivotY = 1f;

            // Calculate global width and height of the tool tip
            float width = rectTransform.rect.width * rectTransform.transform.localScale.x;
            float height = rectTransform.rect.height * rectTransform.transform.localScale.y;
         
            // If any part of the tooltip leaves the screen then shift the anchor point along the axis. 
            if (position.x + width > Screen.width) pivotX = 1f;
            if (position.y - height < 0) pivotY = 0f;
            break;
         case PosType.FixedBot:
            pivotY = 0f;
            pivotX = 0f;
            
            position.x = 5;
            position.y = 5;
            break;
      }

      rectTransform.pivot = new Vector2(pivotX, pivotY);
      transform.position = position;
   }
}
