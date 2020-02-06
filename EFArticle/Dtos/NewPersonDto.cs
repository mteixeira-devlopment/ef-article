namespace EFArticle.Dtos
{
    public class NewPersonDto
    {
        public string Name { get; set; }
        
        public string UniqueIdentifierRegister { get; set; }
        public string? DriveLicence { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }


    }
}
