using System;
namespace Mosfin.Clients.Common.Contracts.Device
{
    public interface IFileSystemStorage
    {


		bool SaveFile(byte[] bytes, String localFileName);
		bool SaveFile(byte[] bytes, string folder, string localFileName);
		String ReadFilePath(string fileName);
		String ReadFilePath(string folder, string fileName);
		string[] GetAllFilesInFolder(string folderName);
    }
}
