using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewAssets : MonoBehaviour
{
    public Text descriptionText;
    public MeshFilter vase3DMesh;
    public MeshRenderer vasesMeshRenderer;
    public Material vaseMaterial1;
    public Material vaseMaterial2;
    public Mesh[] possibleVaseMesh;

    // Start is called before the first frame update
    void Start()
    {
        switch (VaseManager.instance.idVase)
        {
            case 1:
                descriptionText.text = "An ancient vase of the 9th century, it is possible to observe various decorations";
                vase3DMesh.mesh = possibleVaseMesh[0];
                vasesMeshRenderer.material = vaseMaterial1;
                break;
            case 2:
                descriptionText.text = "A broken vase found on the edge of the country, rebuilt according to international rules.";
                vase3DMesh.mesh = possibleVaseMesh[1];
                vasesMeshRenderer.material = vaseMaterial1;
                break;
            case 3:
                descriptionText.text = "The most ancient vase found in north Italy, found around 500.";
                vase3DMesh.mesh = possibleVaseMesh[2];
                vasesMeshRenderer.material = vaseMaterial1;
                break;
            case 4:
                descriptionText.text = "The most preserved vase of the museum, belonging to the 10th century.";
                vase3DMesh.mesh = possibleVaseMesh[3];
                vasesMeshRenderer.material = vaseMaterial1;
                break;
            case 5:
                descriptionText.text = "An ancient vase rebuilt for the museum, this is the original piece from the 8th century.";
                vase3DMesh.mesh = possibleVaseMesh[4];
                vasesMeshRenderer.material = vaseMaterial2;
                break;
            case 6:
                descriptionText.text = "Vase from 600, presents various decorations."; 
                vase3DMesh.mesh = possibleVaseMesh[5];
                vasesMeshRenderer.material = vaseMaterial2;
                break;
            case 7:
                descriptionText.text = "An ancient vase belonging to a rich family of the country.";
                vase3DMesh.mesh = possibleVaseMesh[6];
                vasesMeshRenderer.material = vaseMaterial2;
                break;
        }
    }

    
}
