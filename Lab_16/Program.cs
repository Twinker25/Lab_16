using System.Text;

namespace Lab_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter task (1 - 4): ");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Console.Write("Enter path of file: ");
                        string pathFile = Console.ReadLine();
                        Console.Write("Enter path to copy file: ");
                        string copyFile = Console.ReadLine();
                        try
                        {
                            File.Copy(pathFile, copyFile);
                            Console.WriteLine("File copied successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Failed to copy the file: " + ex.Message);
                        }
                        break;
                    case 2:
                        Console.Write("Enter path of file: ");
                        string pathFile2 = Console.ReadLine();
                        Console.Write("Enter path to replace file: ");
                        string replaceFile = Console.ReadLine();
                        try
                        {
                            File.Move(pathFile2, replaceFile);
                            Console.WriteLine("File replace successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Failed to replace the file: " + ex.Message);
                        }
                        break;
                    case 3:
                        Console.Write("Enter path of folder: ");
                        string pathFolder = Console.ReadLine();
                        Console.Write("Enter path to copy folder: ");
                        string copyFolder = Console.ReadLine();
                        try
                        {

                            if (Directory.Exists(pathFolder))
                            {
                                CopyDirectory(pathFolder, copyFolder);
                                Console.WriteLine("Folder copy successfully.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Failed to copy the folder: " + ex.Message);
                        }
                        break;
                    case 4:
                        Console.Write("Enter path of folder: ");
                        string pathFolder2 = Console.ReadLine();
                        Console.Write("Enter path to replace folder: ");
                        string replaceFolder = Console.ReadLine();
                        try
                        {
                            Directory.Move(pathFolder2, replaceFolder);
                            Console.WriteLine("Folder replace successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Failed to replace the folder: " + ex.Message);
                        }
                        break;
                    default: 
                        Console.WriteLine("Error!"); 
                        break;
                }
            }
        }

        static void CopyDirectory(string sourceDirectory, string destinationDirectory)
        {
            Directory.CreateDirectory(destinationDirectory);

            string[] directories = Directory.GetDirectories(sourceDirectory);
            string[] files = Directory.GetFiles(sourceDirectory);

            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destinationFilePath = Path.Combine(destinationDirectory, fileName);
                File.Copy(file, destinationFilePath, true);
            }

            foreach (string directory in directories)
            {
                string directoryName = Path.GetFileName(directory);
                string destinationSubDirectoryPath = Path.Combine(destinationDirectory, directoryName);
                CopyDirectory(directory, destinationSubDirectoryPath);
            }
        }
    }
}