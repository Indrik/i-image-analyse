using Ia.Domain.Interfaces;

namespace Ia.Business
{
    public class FileCompare
    {
        private readonly IDirectoryReader directoryReader;

        public FileCompare(IDirectoryReader directoryReader)
        {
            this.directoryReader = directoryReader;
        }
    }
}