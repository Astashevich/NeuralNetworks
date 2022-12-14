using System.Drawing;

namespace NeuralNetworks
{
    public class PictureConverter
    {
        public int Boundary { get; set; } = 128;
        public int Width { get; set; }
        public int Height { get; set; }

        public double[] Convert(string path)
        {
            var result = new List<double>();

            var image = new Bitmap(path);
            var resizeImage = new Bitmap(image, new Size(20, 20));
            Width = resizeImage.Width;
            Height = resizeImage.Height;

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var pixel = resizeImage.GetPixel(x, y);
                    result.Add(Brightness(pixel));
                }
            }
            return result.ToArray();
        }

        private int Brightness(Color pixel)
        {
            var result = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B;
            return result < Boundary ? 0 : 1;
        }

        public void Save(string path, double[] pixels)
        {
            var image = new Bitmap(Width, Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var color = pixels[y * Width + x] == 1 ? Color.White : Color.Black;
                    image.SetPixel(x, y, color);
                }
            }
            image.Save(path);
        }
    }
}
