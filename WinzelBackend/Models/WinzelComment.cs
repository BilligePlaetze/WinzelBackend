namespace WinzelBackend.Models
{
    public class WinzelComment
    {
        public long Id { get; set; }
        public WinzelTextContent WinzelContent { get; set; }
        public WinzelAuthor WinzelAuthor { get; set; }
        public WinzelLocation WinzelLocation { get; set; }
    }
}
