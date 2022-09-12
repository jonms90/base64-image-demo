# base64-image-demo

A demonstration of uploading images to web apis using base64 encoded strings. 

**Warning: This repository is for demo purposes only and should not be used directly in any production environment.**

This demo contains two projects:
1. Base64.Demo.Api
2. Base64.Demo.Console

Base64.Demo.Api is a simple .NET 6 ASP.NET Core web api that has a single controller ImageController with a POST endpoint. It receives image uploads as a model containing an image name and the image data as a base64 string. The endpoint then converts the base64 encoded string back into binary and saves the image file in a temp folder.

Base64.Demo.Console is a simple .NET 6 Console application that reads a binary file (a sample .jpg image), converts it to a base64 encoded string and posts the data to the Image endpoints of the Base64.Demo.Api. The console application also contains code for printing the base64 encoded string and saving it to a temp file.
