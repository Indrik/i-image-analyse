namespace Ia.Domain.Models
{
    public class ImageInfo
    {
        public ImageInfo(string path, string name)
        {
            Path = path;
            Name = name;
        }
        
        public int Width { get; set; }
        public int Height { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}