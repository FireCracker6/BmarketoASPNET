namespace BMarketo.ViewModels;

public class GridCollectionSmallCardsItemViewModel
{
    public string Id { get; set; } = null!;
    public byte[] Image { get; set; }
    public string MimeType { get; set; } = null!;
    public List<byte[]> Images { get; set; } = new List<byte[]>();
    public string Url { get; set; } = null!;


}
