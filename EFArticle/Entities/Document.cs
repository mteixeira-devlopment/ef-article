namespace EFArticle.Entities
{
    public class Document
    {
        public string UniqueIdentifierRegister { get; }
        public string DriveLicence { get; }

        public Document(string uniqueIdentifierRegister, string driveLicence = null)
        {
            UniqueIdentifierRegister = uniqueIdentifierRegister;
            DriveLicence = driveLicence;
        }
    }
}