using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace LearnCommonClassMethods;

[TestClass]
public class LearnIO
{
    [TestMethod]
    public void SizeOfThings()
    {
        Assert.AreEqual(4,sizeof(int));
        Assert.AreEqual(8, sizeof(long));
        byte[] byteArray = new byte[1024 * 1024];
        Assert.AreEqual(1024*1024, byteArray.Length);
        // the actual smallest unit in C# is a single byte

        HashAlgorithm hasher = MD5.Create(); // message digest version 5, now not used for cryptography but still used for integrity
        
        byte[] greeting = Encoding.UTF8.GetBytes("HelloWorld"); // regardles of size of source file, the hash is always the same size
        byte[] thumbprint = hasher.ComputeHash(greeting);
        Debug.WriteLine(BitConverter.ToString(thumbprint));

    }

    [TestMethod]
    public void GenerateAListOfFilesTest()
    {
        string currentDir = AppDomain.CurrentDomain.BaseDirectory;
        // tells the current directory

        string[] fileNames = Directory.GetFiles(currentDir); // static class

        DirectoryInfo dirInfo = new DirectoryInfo(currentDir);

        Dictionary<byte[], FileInfo> hashLookup = new();// instance class
        FileInfo[] files = dirInfo.GetFiles();
        // Directory static class is only returning an array of strings,
        // Files would be the exact 27 things, including properties like when created, extension, etc.
        HashAlgorithm hasher = SHA256.Create();

        foreach (var file in files)
        {
            using (FileStream fs = file.OpenRead())
            {
                byte[] fileHash = hasher.ComputeHash(fs);
                hashLookup.Add(fileHash, file);
            }
            // fs.Close(); using using will release things when we are done automatically, using will automatically call
            // dispose on file stream as soon as it is done
            // the hash is on the file contents, not the name
        }



    }

    [TestMethod]
    public void WorkWithStream()
    {

        string fileName = "test.bin";
        string directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string filePath = Path.Combine(directory, fileName);

        Stream aStream = new FileStream(filePath, FileMode.OpenOrCreate);
        for (byte i = 1; i < 128; i++)
        {
            aStream.WriteByte(i);
        }
        Debug.Print(aStream.Position.ToString());
        Debug.Print($"Can Seek:{aStream.CanSeek}");
        Debug.Print($"Can Seek:{aStream.CanRead}");
        Debug.Print($"Can Seek:{aStream.CanWrite}");

        if (aStream.CanSeek) aStream.Position = 0;
        for (byte i = 127; i > 0; i--)
        {
            aStream.WriteByte(i);
        }

        if (aStream.CanSeek) aStream.Position = 50;

        byte[] buffer = new byte[10*1024*1024]; // create 10 MB bufer
        while (aStream.Position < aStream.Length)
        {
            aStream.ReadExactly(buffer, 0, (int)Math.Min(buffer.Length, aStream.Length - aStream.Position)); // scoop up 10MB at a time
            // if we have 10 MB read 10 MB, otherwise read whatever is left over
        }

        aStream.Close();

    }

    [TestMethod]
    public void ReaderWriterTest()
    {
        // pipe and filter

        // Binary Reader/Writer provide binary primitive reader/writer helper methods
        string fileName = "binRW.bin";
        string directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string filePath = Path.Combine(directory, fileName);
        Stream aStream = new FileStream(filePath, FileMode.OpenOrCreate);

        BinaryWriter writer = new BinaryWriter(aStream);

        writer.Write(100); // 4 bytes
        writer.Write(500.50); // 8 bytes
        writer.Write(250.50f); // 8 bytes
        writer.Write(123.4567M); // 16 bytes
        writer.Write(true); // 1 byte
        writer.Write('h'); // 1 byte
        writer.Write(long.MaxValue); // 8 bytes
        aStream.Position = 0; // rewind stream back to begining

        BinaryReader reader = new BinaryReader(aStream);
        Assert.AreEqual(100, reader.ReadInt32());
        Assert.AreEqual(500.50, reader.ReadDouble());
        Assert.AreEqual(250.50f, reader.ReadSingle());
        Assert.AreEqual(123.4567M, reader.ReadDecimal());
        Assert.AreEqual(true, reader.ReadBoolean());
        Assert.AreEqual('h', reader.ReadChar());
        Assert.AreEqual(long.MaxValue, reader.ReadInt64());
        Assert.AreEqual(42, aStream.Length);
        aStream.Close();

        // Stream Reader/Writer provide text writing helper methods
        //StreamReader
        //StreamWriter
    }
}
