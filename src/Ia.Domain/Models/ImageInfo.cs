namespace Ia.Domain.Models
{
    public class ImageInfo
    {
        public ImageInfo()
        {
            Path = string.Empty;
            Name = string.Empty;
        }
        
        public ImageInfo(string path, string name)
        {
            Path = path;
            Name = name;
        }
        
        public int Width { get; set; }
        public int Height { get; set; }
        public string Name { get; }
        public string Path { get; }

        public int Area => Width * Height;
    }
}