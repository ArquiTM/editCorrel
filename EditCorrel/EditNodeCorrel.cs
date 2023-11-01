using System.IO;

namespace EditCorrel
{
    class EditNodeCorrel
    {
        public void changeLineCorrel()//Remove a node part of correl file
        {
            string directoryPath = @".\correl";
            string fileExtension = ".correl";
            string originalXmlString = "<CorrelationData xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"http://www.motorolamobility.com/globaltest/nextest2010/correlation\">";
            string replacementXmlString = "<CorrelationData>";
            string[] files = Directory.GetFiles(directoryPath, "*" + fileExtension);

            foreach (string filePath in files)
            {
                try
                {
                    string xmlContent = File.ReadAllText(filePath);
                    xmlContent = xmlContent.Replace(originalXmlString, replacementXmlString);
                    File.WriteAllText(filePath, xmlContent);
                }
                catch
                { }
            }
        }

        public void reWriteLineCorrel()//Insert a node part of correl
        {
            if (!Directory.Exists(@"correl"))
                Directory.CreateDirectory(@"correl");

            string directoryPath = @".\correl";
            string fileExtension = ".correl";
            string replacementXmlString = "<CorrelationData xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns=\"http://www.motorolamobility.com/globaltest/nextest2010/correlation\">";
            string actualXmlString = "<CorrelationData>";
            string[] files = Directory.GetFiles(directoryPath, "*" + fileExtension);

            foreach (string filePath in files)
            {
                try
                {
                    string xmlContent = File.ReadAllText(filePath);
                    xmlContent = xmlContent.Replace(actualXmlString, replacementXmlString);
                    File.WriteAllText(filePath, xmlContent);
                }
                catch
                { }
            }
        }
    }
}
