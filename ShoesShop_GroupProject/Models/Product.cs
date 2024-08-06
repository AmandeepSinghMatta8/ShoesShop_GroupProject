using System.ComponentModel.DataAnnotations;

public class Product
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    public int Stock { get; set; }

    public string Brand { get; set; }

    public string Category { get; set; }

    public byte[] ImageData { get; set; } // Store the image as a byte array

    public string ImageMimeType { get; set; } // Store the MIME type of the image
}
