using UnityEngine;
using System.Collections;
using System.IO;

public class cameraRender : MonoBehaviour 
{
    WebCamTexture webCamTexture;
	Color32[] data;
    IEnumerator Start() 
    {
		 print("Starting " + Time.time);

		WebCamDevice device = WebCamTexture.devices[0];
		string deviceName= device.name;
        webCamTexture = new WebCamTexture(deviceName);
		
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
		int dataNum = webCamTexture.width* webCamTexture.height;
		data = new Color32[dataNum];
        Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
        photo.SetPixels32(webCamTexture.GetPixels32());
        photo.Apply();
		GetComponent<Renderer>().material.mainTexture = photo;
		byte[] bytes = photo.EncodeToPNG();
		Destroy(photo);
		System.IO.File.WriteAllBytes( "face12.png", bytes);
		// byte[] bytes = photo.EncodeToPNG();
        // //Write out the PNG. Of course you have to substitute your_path for something sensible
        // File.WriteAllBytes("/Users/kimashmore/SUPER systems/photo.png", bytes);

		//Lines relative to stopping camera and capturing photo
		
		//  photo.ReadPixels(new Rect(0, 0, webCamTexture.width, webCamTexture.height), 0, 0);
    }
}
// using UnityEngine;
// using System.Collections;
 
//  public class cameraRender : MonoBehaviour {
//    public string deviceName;
//    WebCamTexture wct;
//       // For photo varibles
   
//    public Texture2D heightmap;
//    public Vector3 size = new Vector3(100, 10, 100);
//    // For saving to the _savepath
//    string _SavePath = "/Users/kimashmore/SUPER systems/Assets/"; //Change the path here!
//    int _CaptureCounter = 0;
   
//    // Use this for initialization
//    void Start () {
//      WebCamDevice[] devices = WebCamTexture.devices;
//      deviceName = devices[0].name;
// 	 if (Input.GetButtonDown("Mouse X")){
// 		   Debug.Log("hfkdsnckldsals");
// 		   wct = new WebCamTexture(deviceName, 400, 300, 12);
// 		   GetComponent<Renderer>().material.mainTexture = wct;
// 		   wct.Play();
// 		   TakeSnapshot();
// 		   }
//    }

   
   

   
// //    void OnGUI() {   
// // 	   if (Input.GetButtonDown("Mouse X")){
// // 		   Debug.Log("hfkdsnckldsals");
// // 	          TakeSnapshot();
// // 	   }
// //     //  if (GUI.Button(new Rect(10, 70, 50, 30), "Click"))

     

//    void TakeSnapshot()
//      {
//        Texture2D snap = new Texture2D(wct.width, wct.height);
//        snap.SetPixels(wct.GetPixels());
//        snap.Apply();
 
//        System.IO.File.WriteAllBytes(_SavePath + _CaptureCounter.ToString() + ".png", snap.EncodeToPNG());
//        ++_CaptureCounter;
//    }
//  }
// using UnityEngine;
// using System.Collections;
// using System.IO;

// public class cameraRender : MonoBehaviour 
// {
//     WebCamTexture webCamTexture;
// 	Color32[] data;
//     IEnumerator Start() 
//     {
// 		 print("Starting " + Time.time);

// 		WebCamDevice device = WebCamTexture.devices[0];
// 		string deviceName= device.name;
//         webCamTexture = new WebCamTexture(deviceName);
		
//         GetComponent<Renderer>().material.mainTexture = webCamTexture; //Add Mesh Renderer to the GameObject to which this script is attached to
//         webCamTexture.Play();

// 		// webCamTexture.Stop();
// 		yield return StartCoroutine(TakePhoto());
// 		print("Done " + Time.time);

//     }

//     IEnumerator TakePhoto()  // Start this Coroutine on some button click
//     {

//     // NOTE - you almost certainly have to do this here:

//      yield return new WaitForEndOfFrame(); 

//     // it's a rare case where the Unity doco is pretty clear,
//     // http://docs.unity3d.com/ScriptReference/WaitForEndOfFrame.html
//     // be sure to scroll down to the SECOND long example on that doco page 
// 		int dataNum = webCamTexture.width* webCamTexture.height;
// 		data = new Color32[dataNum];
//         Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
//         photo.SetPixels32(webCamTexture.GetPixels32());
//         photo.Apply();
// 		 GetComponent<Renderer>().material.mainTexture = photo;
// 		byte[] bytes = photo.EncodeToPNG();
// 		System.IO.File.WriteAllBytes( "face1.png", bytes);
// 		// byte[] bytes = photo.EncodeToPNG();
//         // //Write out the PNG. Of course you have to substitute your_path for something sensible
//         // File.WriteAllBytes("/Users/kimashmore/SUPER systems/photo.png", bytes);

// 		//Lines relative to stopping camera and capturing photo
		
// 		//  photo.ReadPixels(new Rect(0, 0, webCamTexture.width, webCamTexture.height), 0, 0);
//     }
// }



// // using System.IO;
// // using UnityEngine;
// // using UnityEngine.Networking;
// // using System.Collections;

// // public class cameraRender : MonoBehaviour
// // {
// //     WebCamTexture webCamTexture;
// // 	WebCamDevice device = WebCamTexture.devices[0];
// //     // Take a shot immediately
// //     IEnumerator Start()
// //     {
// //         webCamTexture = new WebCamTexture(device.name);
// //         GetComponent<Renderer>().material.mainTexture = webCamTexture; //Add Mesh Renderer to the GameObject to which this script is attached to
// //         webCamTexture.Play();
// //         // We should only read the screen buffer after rendering is complete
// //         yield return new WaitForEndOfFrame();
// // 		        // Create a texture the size of the screen, RGB24 format
// //         int width = webCamTexture.width;
// //         int height = webCamTexture.height;
		
// // 		Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
// //         photo.SetPixels(webCamTexture.GetPixels());
// //         photo.Apply();

// //         // Texture2D photo = new Texture2D(width, height);

// //         // // // Read screen contents into the texture
// //         // // photo.ReadPixels(new Rect(0, 0, width, height), 0, 0);
// //         // // photo.Apply();

// //         // Encode texture into PNG
// //         byte[] bytes = photo.EncodeToPNG();
// //         Destroy(photo);
		
// // 		webCamTexture.Stop();
        
// //         // For testing purposes, also write to a file in the project folder
// //         File.WriteAllBytes(Application.dataPath + "/SavedScreen.png", bytes);
// //         // UploadPNG();
// //         yield return null;
// //     }

// //     // IEnumerator UploadPNG()
// //     // {
// //     //     // We should only read the screen buffer after rendering is complete
// //     //     yield return new WaitForEndOfFrame();

// //     //     // Create a texture the size of the screen, RGB24 format
// //     //     int width = Screen.width;
// //     //     int height = Screen.height;
// //     //     Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);

// //     //     // Read screen contents into the texture
// //     //     photo.ReadPixels(new Rect(0, 0, webCamTexture.width, webCamTexture.height), 0, 0);
// //     //     photo.Apply();

// //     //     // Encode texture into PNG
// //     //     byte[] bytes = photo.EncodeToPNG();
// //     //     Destroy(photo);

// //     //     // For testing purposes, also write to a file in the project folder
// //     //     File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);
// //     // }
// // }
