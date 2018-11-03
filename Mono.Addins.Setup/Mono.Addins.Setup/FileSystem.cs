namespace Mono.Addins.Setup
{
	class FileSystem
	{
		public class File
		{
			public static void Delete (string filePath)
			{
				ThrowIfFileLocked (filePath);
				System.IO.File.Delete (filePath);
			}

			public static void Copy (string sourcePath, string destinationPath, bool overwrite = false)
			{
				ThrowIfFileLocked (destinationPath);
				System.IO.File.Copy (sourcePath, destinationPath, overwrite);
			}

			public static void ThrowIfFileLocked (string filePath)
			{
				var locks = LockCheck.GetProcessesLockingFile (filePath);
				if (!string.IsNullOrEmpty (locks)) {
					throw new System.Exception (locks);
				}
			}
		}
	}
}