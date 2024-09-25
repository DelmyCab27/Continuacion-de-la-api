namespace manga.Domain.Dtos;

public class MangaUpdateDTO
{
    public string Title { get; set;} = null!;
    public string Author { get; set;} = null!;
    public int PublicationYear { get; set; }
}