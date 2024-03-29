using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading.Tasks;


namespace TasteOfLoveR;

public class ImageConvertor
{
    public static void ConvertImageToAscii(string imagePath)
    {
        const string asciiChars = "  .,:ilwW@@";
        bool invert = true;
        string imageText = string.Empty;
        StringBuilder st = new StringBuilder();
        Image image = null;

        using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
        {
            image = Image.FromStream(imageStream);
        }

        int width = 200;
        int height = (int)(width * image.Height / image.Width * 0.55);

        using Bitmap newImage = new Bitmap(width, height);

        using (Graphics graphics = Graphics.FromImage(newImage))
        {
            graphics.DrawImage(image, 0, 0, width, height);
        }

        for (int i = 0; i < newImage.Height; i++)
        {
            for (int j = 0; j < newImage.Width; j++)
            {
                Color pixelColor = newImage.GetPixel(j,i);
                int grayColor = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                Console.Write(asciiChars[grayColor * asciiChars.Length / 255 % asciiChars.Length]);
                imageText += asciiChars[grayColor * asciiChars.Length / 255 % asciiChars.Length];
                st.Append(asciiChars[grayColor * asciiChars.Length / 255 % asciiChars.Length]);

                //if (grayColor < 128)
                //    Console.Write(invert ? "1" : "0");
                //else
                //    Console.Write(invert ? "0" : "1");
            }
            Console.WriteLine();
            imageText += "\n";
            st.Append('\n');
        }

        SaveTextAsImage(imageText, @"C:\Users\Arian\Desktop\" + Guid.NewGuid().ToString() + ".png");
    }

    public static void SaveTextAsImage(string inputText, string outputPath)
    {
        // Set font and brush for drawing text
        Font font = new Font("Consolas", 24, FontStyle.Regular);
        Brush brush = Brushes.White;

        // Create a temporary bitmap to calculate the size of the text
        using (Bitmap tempBitmap = new Bitmap(1, 1))
        {
            using (Graphics tempGraphics = Graphics.FromImage(tempBitmap))
            {
                // Measure the size of the text
                SizeF textSize = tempGraphics.MeasureString(inputText, font);

                // Create a new bitmap with the correct dimensions
                Bitmap bitmap = new Bitmap((int)Math.Ceiling(textSize.Width), (int)Math.Ceiling(textSize.Height));

                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.Black);

                    // Draw the text on the bitmap
                    graphics.DrawString(inputText, font, brush, new PointF(0, 0));

                    // Save the bitmap as an image file
                    bitmap.Save(outputPath, ImageFormat.Png);
                }
            }
        }
    }


    public static bool TestIsImage(string fileName)
    {
        try
        {
            var img = System.Drawing.Image.FromFile(fileName);
            return true;
        }
        catch
        {
            return false;
        }
    }
}