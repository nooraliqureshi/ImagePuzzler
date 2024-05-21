using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ImagePuzzlerLibrary;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: ImagePuzzler <operation> <imagePath> <pattern>");
            Console.WriteLine("operation: puzzle or resolve");
            Console.WriteLine("imagePath: Path to the image file");
            Console.WriteLine("pattern: Comma-separated numbers, e.g., 6,1,3,5,2,4");
            return;
        }

        string operation = args[0];
        string imagePath = args[1];
        string patternInput = args[2];

        if (!File.Exists(imagePath))
        {
            Console.WriteLine("The specified file does not exist.");
            return;
        }

        Bitmap image;
        try
        {
            image = new Bitmap(imagePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading image: {ex.Message}");
            return;
        }

        int[] pattern = ParsePattern(patternInput);
        if (pattern == null || pattern.Length == 0)
        {
            Console.WriteLine("Invalid pattern.");
            return;
        }

        switch (operation.ToLower())
        {
            case "puzzle":
                PuzzleImage(image, imagePath, pattern);
                break;
            case "resolve":
                ResolveImage(image, imagePath, pattern);
                break;
            default:
                Console.WriteLine("Invalid operation. Use 'puzzle' or 'resolve'.");
                break;
        }
    }

    private static int[] ParsePattern(string patternInput)
    {
        try
        {
            if (patternInput.Contains(","))
            {
                return Array.ConvertAll(patternInput.Split(','), int.Parse);
            }
            else
            {
                return patternInput.Select(ch => int.Parse(ch.ToString())).ToArray();
            }
        }
        catch
        {
            return null;
        }
    }

    private static void PuzzleImage(Bitmap originalImage, string imagePath, int[] pattern)
    {
        Bitmap puzzleImage = ImagePuzzler.CreatePuzzle(originalImage, pattern, pattern.Length);
        SaveImage(puzzleImage, imagePath, "puzzle");
    }

    private static void ResolveImage(Bitmap puzzleImage, string imagePath, int[] pattern)
    {
        Bitmap resolvedImage = ImagePuzzler.ResolvePuzzle(puzzleImage, pattern, pattern.Length);
        SaveImage(resolvedImage, imagePath, "resolved");
    }

    private static void SaveImage(Bitmap image, string originalImagePath, string suffix)
    {
        string directory = Path.GetDirectoryName(originalImagePath);
        string originalFileName = Path.GetFileNameWithoutExtension(originalImagePath);
        string extension = Path.GetExtension(originalImagePath);

        string newFileName = $"{originalFileName}_{suffix}{extension}";
        string newFilePath = Path.Combine(directory, newFileName);

        try
        {
            image.Save(newFilePath, GetImageFormat(extension));
            Console.WriteLine($"Image saved as {newFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving image: {ex.Message}");
        }
    }

    private static ImageFormat GetImageFormat(string extension)
    {
        switch (extension.ToLower())
        {
            case ".bmp":
                return ImageFormat.Bmp;
            case ".png":
                return ImageFormat.Png;
            case ".jpg":
            case ".jpeg":
            default:
                return ImageFormat.Jpeg;
        }
    }
}