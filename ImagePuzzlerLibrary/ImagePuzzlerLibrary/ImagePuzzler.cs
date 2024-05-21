using System;
using System.Collections.Generic;
using System.Drawing;

namespace ImagePuzzlerLibrary
{
    public class ImagePuzzler
    {
        // Function to create an image puzzle based on the pattern
        public static Bitmap CreatePuzzle(Bitmap image, int[] pattern, int numberOfPieces)
        {
            // Validate inputs
            if (image == null)
                throw new ArgumentNullException(nameof(image)); // Throw ArgumentNullException if image is null

            if (pattern == null || pattern.Length != numberOfPieces)
                throw new ArgumentException("Pattern length does not match number of pieces."); // Throw ArgumentException if pattern is null or its length doesn't match the number of pieces

            // Slice the image into equal pieces
            List<Bitmap> pieces = SliceImage(image, numberOfPieces);

            // Arrange pieces according to the given pattern
            Bitmap arrangedImage = ArrangePieces(pieces, pattern);

            return arrangedImage;
        }

        // Function to resolve the image puzzle based on the pattern
        public static Bitmap ResolvePuzzle(Bitmap image, int[] pattern, int numberOfPieces)
        {
            // Convert the pattern to resolve it
            int[] newPattern = ConvertResolvePattern(pattern);

            // Validate the length of the new pattern
            if (newPattern.Length != numberOfPieces)
                throw new ArgumentException("Pattern length does not match number of pieces."); // Throw ArgumentException if the length of the new pattern doesn't match the number of pieces

            // Create the image puzzle using the resolved pattern
            Bitmap imagePuzzle = CreatePuzzle(image, newPattern, numberOfPieces);
            return imagePuzzle;
        }

        // Function to convert the pattern for resolving the puzzle
        private static int[] ConvertResolvePattern(int[] pattern)
        {
            int[] newPattern = new int[pattern.Length];

            // Loop through the pattern array
            for (int i = 0; i < pattern.Length; i++)
            {
                // Validate each element of the pattern
                if (pattern[i] < 1 || pattern[i] > pattern.Length)
                {
                    throw new ArgumentException("Pattern contains invalid values."); // Throw ArgumentException if the pattern contains invalid values
                }

                // Assign the pattern value to the new pattern array
                newPattern[i] = pattern[i];
            }

            // Reassign the pattern values to resolve the puzzle
            for (int i = 0; i < pattern.Length; i++)
            {
                newPattern[pattern[i] - 1] = i + 1;
            }

            return newPattern;
        }

        // Helper method to slice the image into equal pieces
        private static List<Bitmap> SliceImage(Bitmap image, int numberOfPieces)
        {
            List<Bitmap> pieces = new List<Bitmap>();

            // Calculate the width and height of each piece
            int pieceWidth = image.Width / numberOfPieces;
            int pieceHeight = image.Height;

            // Iterate through each piece and slice the image
            for (int i = 0; i < numberOfPieces; i++)
            {
                int x = i * pieceWidth;
                int width = (i == numberOfPieces - 1) ? image.Width - x : pieceWidth;

                // Define the rectangle for the piece
                Rectangle rect = new Rectangle(x, 0, width, pieceHeight);
                // Clone the piece from the original image
                Bitmap piece = image.Clone(rect, image.PixelFormat);
                pieces.Add(piece);
            }

            return pieces;
        }

        // Helper method to arrange pieces according to the pattern
        private static Bitmap ArrangePieces(List<Bitmap> pieces, int[] pattern)
        {
            // Get dimensions for each piece
            int pieceWidth = pieces[0].Width;
            int pieceHeight = pieces[0].Height;

            // Create a new bitmap to arrange the pieces
            Bitmap arrangedImage = new Bitmap(pieceWidth * pattern.Length, pieceHeight);

            using (Graphics g = Graphics.FromImage(arrangedImage))
            {
                for (int i = 0; i < pattern.Length; i++)
                {
                    // Determine the index of the piece in the pattern
                    int pieceIndex = pattern[i] - 1; // Adjust for 1-based index
                    Bitmap piece = pieces[pieceIndex];
                    // Draw the piece at the correct position
                    g.DrawImage(piece, i * pieceWidth, 0);
                }
            }

            return arrangedImage;
        }
    }
}