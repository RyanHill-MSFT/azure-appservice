using Microsoft.Azure.Mobile.Server;

namespace LCARS.Command.Processor.Chi._48.Models
{
    public class Candidate : EntityData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PlaceOfOrigin { get; set; }
        public string LetterOfRecommendation { get; set; }
    }
}
