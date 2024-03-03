/*
* Find Treatment
*/

namespace FindTreatment.Reporting;

public class FileManager : IFileManager
{
    // Can do things like check for if excel file, is valid, etc.
    public bool Exists(string fileName) => File.Exists(fileName);
}