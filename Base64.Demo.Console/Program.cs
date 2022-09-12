using System.Text;
using System.Text.Json;
using Base64.Demo.Console;

Console.WriteLine("Image to Base64 string demo.");

var demoImagePath = @"..\..\..\..\Images\demo-profile-pic.jpg";
if (File.Exists(demoImagePath))
{
    var file = await File.ReadAllBytesAsync(demoImagePath);
    var encoded = Convert.ToBase64String(file);

    // PrintEncodedString(encoded);
    // await SaveEncodedStringAsync(encoded);

    Console.WriteLine("Press any key to upload image to API.");
    Console.ReadKey(true);

    var imageUpload = new ImageUpload { Name = "profile-pic.jpg", Data = encoded };

    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("https://localhost:7280");
        var body = JsonSerializer.Serialize(imageUpload);
        await client.PostAsync("/Image",
            new StringContent(body, Encoding.UTF8, "application/json"));
    }

    Console.WriteLine("Press any key to exit.");
    Console.ReadKey(true);
}
else
{
    Console.Error.WriteLine($"Could not find demo picture at the expected path: {demoImagePath}");
}

void PrintEncodedString(string s)
{
    Console.WriteLine($"Image file as a Base64 encoded string: {s}");
}

async Task SaveEncodedStringAsync(string encoded1)
{
    var tempFile = Path.GetTempFileName();
    await File.WriteAllBytesAsync(tempFile, Encoding.ASCII.GetBytes(encoded1));
    Console.WriteLine($"Saved file at location: {tempFile}");
}

