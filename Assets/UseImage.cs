// // using cameraRender; 

// // Load an image from a local file.
// var filePAth  = "photo.png"
// var image = Image.FromFile(filePath);
// var client = ImageAnnotatorClient.Create();
// var response = client.DetectFaces(image);
// int count = 1;
// foreach (var faceAnnotation in response)
// {
//     Console.WriteLine("Face {0}:", count++);
//     Console.WriteLine("  Joy: {0}", faceAnnotation.JoyLikelihood);
//     Console.WriteLine("  Anger: {0}", faceAnnotation.AngerLikelihood);
//     Console.WriteLine("  Sorrow: {0}", faceAnnotation.SorrowLikelihood);
//     Console.WriteLine("  Surprise: {0}", faceAnnotation.SurpriseLikelihood);
// }
