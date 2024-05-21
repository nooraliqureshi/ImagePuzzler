
# Image Puzzler

Image Puzzler is a C# application that allows users to create and solve image puzzles. This project consists of two main parts: a C# library that handles the core functionality and a Windows Forms application that provides a user interface for interacting with the library.

**C# Library: ImagePuzzlerLibrary**
The ` **ImagePuzzlerLibrary** ` is a C# library designed to create and resolve image puzzles. It provides methods to slice images into pieces and arrange them according to a specified pattern.


## Features

- Create Puzzle: Slice an image into pieces and arrange them in a specified pattern.
- Resolve Puzzle: Rearrange the pieces of a shuffled image back to the original order.
- Load Image: Load an image from the file system.
- Download Image: Save the current image (original, shuffled, or resolved) to the file system.
- Reset Fields: Clear the current image and reset all fields.


## Demo

A demo Windows Forms application is included to demonstrate the functionality of the ImagePuzzlerLibrary.


## Screenshots

**Main Window**
![App Screenshot](https://via.placeholder.com/468x300?text=App+Screenshot+Here)

**Puzzle Creation**
![App Screenshot](https://via.placeholder.com/468x300?text=App+Screenshot+Here)

**Puzzle Resolving**
![App Screenshot](https://via.placeholder.com/468x300?text=App+Screenshot+Here)

## Tech

- C#
- .NET Framework
- Windows Forms


## Installation

Clone the repository:

```bash
  git clone https://github.com/yourusername/image-puzzler.git
```
    
## Usage/Examples

**Library Usage**

``` c#
using System.Drawing;
using ImagePuzzlerLibrary;

// Create a puzzle
Bitmap originalImage = new Bitmap("path_to_image");
int[] pattern = { 6, 1, 3, 5, 2, 4 };
Bitmap puzzleImage = ImagePuzzler.CreatePuzzle(originalImage, pattern, pattern.Length);

// Resolve a puzzle
Bitmap resolvedImage = ImagePuzzler.ResolvePuzzle(puzzleImage, pattern, pattern.Length);
```


## Run Locally

Clone the project

```bash
  git clone https://link-to-project
```

Open the ImagePuzzler project in Visual Studio and run the application.


## Running Tests

To run tests, open the test project(ImagePuzzler) in Visual Studio and run all tests.


## Deployment

Detailed documentation for the library methods can be found here.


## Environment Variables

This project does not require any environment variables.


## Roadmap

- Add more image manipulation features
- Improve UI/UX of the demo application
- Create a web version of the application




## Contributing

Contributions are welcome! Please open an issue or submit a pull request.


## Authors

- [@octokatherine](https://www.github.com/octokatherine)


## License

This project is licensed under the [MIT](https://choosealicense.com/licenses/mit/) License.


## Acknowledgements

- Thanks to all contributors and users who have supported the project.


## Support

For support, open an issue or contact me at mail.nooraliqureshi@gmail.com.

## Feedback

If you have any feedback, please reach out to me at mail.nooraliqureshi@gmail.com.


## FAQ

#### How do I create a custom pattern?

Enter a pattern as a comma-separated list (e.g., "6,1,3,5,2,4") or as a continuous string (e.g., "613524").

