using System.ComponentModel.DataAnnotations;

namespace ShoesShop_GroupProject.Models
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zip Code is required")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name on Card is required")]
        public string CardName { get; set; }

        [Required(ErrorMessage = "Card Number is required")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Expiration Date is required")]
        public string ExpirationDate { get; set; }

        [Required(ErrorMessage = "CVV is required")]
        public string CVV { get; set; }

        public List<CartItem> CartItems { get; set; }

    public decimal GrandTotal
    {
        get { return CartItems?.Sum(ci => ci.Product.Price * ci.Quantity) ?? 0; }
    }
}
}