using TasteOfLoveR;

Console.ForegroundColor = ConsoleColor.Red;

Console.WriteLine(@"
  _____         _                __   _                
 |_   _|_ _ ___| |_ ___    ___  / _| | | _____   _____ 
   | |/ _` / __| __/ _ \  / _ \| |_  | |/ _ \ \ / / _ \
   | | (_| \__ \ ||  __/ | (_) |  _| | | (_) \ V /  __/
   |_|\__,_|___/\__\___|  \___/|_|   |_|\___/ \_/ \___|
                                                       
");

Console.ForegroundColor = ConsoleColor.White;

string imagePath = string.Empty;

while (true)
{
    Console.WriteLine("Please enter your path to a person's image :");
    imagePath = Console.ReadLine();

    if (File.Exists(imagePath))
    {
        if (ImageConvertor.TestIsImage(imagePath))
        {
            break;
        }
    }
}

Console.ForegroundColor = ConsoleColor.Blue;

ImageConvertor.ConvertImageToAscii(imagePath);

Console.ForegroundColor = ConsoleColor.White;

Console.ReadKey();



