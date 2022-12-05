using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderwalls : MonoBehaviour {
     void Start () {
         Vector3 terrainPosition = transform.position;
         Vector3 terrainSize = GetComponent<Terrain>().terrainData.size;
         InstantiateEdgeWidthBorders(terrainPosition, terrainSize);
         InstantiateEdgeLengthBorders(terrainPosition, terrainSize);
     }
     private void InstantiateEdgeWidthBorders(Vector3 terrainPosition, Vector3 terrainSize){
         
         float zOffset = terrainSize.z;
         float xOffset = terrainSize.x / 2; 
         for (int i = 0; i < 2; i++){
             GameObject border = GameObject.CreatePrimitive(PrimitiveType.Cube);
             border.transform.localScale = new Vector3(terrainSize.x,terrainSize.y,1);
             
             if (i == 0)
                 border.transform.position = new Vector3(terrainPosition.x + xOffset, terrainPosition.y, terrainPosition.z);
             else
                 border.transform.position = new Vector3(terrainPosition.x + xOffset, terrainPosition.y, terrainPosition.z + zOffset);
             DisableMeshRenderer(border);
             border.transform.name = "Width Border " + (i + 1);
             border.transform.parent = transform;
         }
     } 
     private void InstantiateEdgeLengthBorders(Vector3 terrainPosition, Vector3 terrainSize){
         float xOffset = terrainSize.x;
         float zOffset = terrainSize.z / 2;
         for (int i = 0; i < 2; i++)
         {
             GameObject border = GameObject.CreatePrimitive(PrimitiveType.Cube);
             border.transform.localScale = new Vector3(1, terrainSize.y, terrainSize.z);
             if (i == 0)
                 border.transform.position = new Vector3(terrainPosition.x, terrainPosition.y, terrainPosition.z + zOffset);
             else
                 border.transform.position = new Vector3(terrainPosition.x + xOffset, terrainPosition.y, terrainPosition.z + zOffset);
             DisableMeshRenderer(border);
             border.transform.name = "Length Border " + (i + 1);
             border.transform.parent = transform;
         }
     }
     private void DisableMeshRenderer(GameObject border){
         border.GetComponent<MeshRenderer>().enabled = false;
     }
 }

