using UnityEngine;
using System.Collections;
using System.IO;

public class cameraRender : MonoBehaviour 
{
    WebCamTexture webCamTexture;

    IEnumerator Start() 
    {
		 print("Starting " + Time.time);

		WebCamDevice device = WebCamTexture.devices[0];
		var deviceName= device.name;
        webCamTexture = new WebCamTexture(deviceName, 400, 300, 12);
        GetComponent<Renderer>().material.mainTexture = webCamTexture; //Add Mesh Renderer to the GameObject to which this script is attached to
        webCamTexture.Play();

		// webCamTexture.Stop();
		yield return StartCoroutine(TakePhoto());
		print("Done " + Time.time);

    }

    IEnumerator TakePhoto()  // Start this Coroutine on some button click
    {

    // NOTE - you almost certainly have to do this here:

     yield return new WaitForEndOfFrame(); 

    // it's a rare case where the Unity doco is pretty clear,
    // http://docs.unity3d.com/ScriptReference/WaitForEndOfFrame.html
    // be sure to scroll down to the SECOND long example on that doco page 

        Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
        photo.SetPixels(webCamTexture.GetPixels(0, 0,webCamTexture.width, webCamTexture.height));
        photo.Apply();
		byte[] bytes = photo.EncodeToPNG();
		System.IO.File.WriteAllBytes( "face1.png", bytes);
		// byte[] bytes = photo.EncodeToPNG();
        // //Write out the PNG. Of course you have to substitute your_path for something sensible
        // File.WriteAllBytes("/Users/kimashmore/SUPER systems/photo.png", bytes);

		//Lines relative to stopping camera and capturing photo
		
		//  photo.ReadPixels(new Rect(0, 0, webCamTexture.width, webCamTexture.height), 0, 0);
    }
}



// using System.IO;
// using UnityEngine;
// using UnityEngine.Networking;
// using System.Collections;

// public class cameraRender : MonoBehaviour
// {
//     WebCamTexture webCamTexture;
// 	WebCamDevice device = WebCamTexture.devices[0];
//     // Take a shot immediately
//     IEnumerator Start()
//     {
//         webCamTexture = new WebCamTexture(device.name);
//         GetComponent<Renderer>().material.mainTexture = webCamTexture; //Add Mesh Renderer to the GameObject to which this script is attached to
//         webCamTexture.Play();
//         // We should only read the screen buffer after rendering is complete
//         yield return new WaitForEndOfFrame();
// 		        // Create a texture the size of the screen, RGB24 format
//         int width = webCamTexture.width;
//         int height = webCamTexture.height;
		
// 		Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
//         photo.SetPixels(webCamTexture.GetPixels());
//         photo.Apply();

//         // Texture2D photo = new Texture2D(width, height);

//         // // // Read screen contents into the texture
//         // // photo.ReadPixels(new Rect(0, 0, width, height), 0, 0);
//         // // photo.Apply();

//         // Encode texture into PNG
//         byte[] bytes = photo.EncodeToPNG();
//         Destroy(photo);
		
// 		webCamTexture.Stop();
        
//         // For testing purposes, also write to a file in the project folder
//         File.WriteAllBytes(Application.dataPath + "/SavedScreen.png", bytes);
//         // UploadPNG();
//         yield return null;
//     }

//     // IEnumerator UploadPNG()
//     // {
//     //     // We should only read the screen buffer after rendering is complete
//     //     yield return new WaitForEndOfFrame();

//     //     // Create a texture the size of the screen, RGB24 format
//     //     int width = Screen.width;
//     //     int height = Screen.height;
//     //     Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);

//     //     // Read screen contents into the texture
//     //     photo.ReadPixels(new Rect(0, 0, webCamTexture.width, webCamTexture.height), 0, 0);
//     //     photo.Apply();

//     //     // Encode texture into PNG
//     //     byte[] bytes = photo.EncodeToPNG();
//     //     Destroy(photo);

//     //     // For testing purposes, also write to a file in the project folder
//     //     File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);
//     // }
// }
