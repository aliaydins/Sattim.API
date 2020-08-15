namespace Sattim.Entities
{
    public interface IFormFile
    {
        decimal Length { get; }
        string FileName { get; }
    }
}