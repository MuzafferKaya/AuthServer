using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entities
{
    [Table("Customers")]
    public class Customer : BaseEntity
    {
        [Required(ErrorMessage = "Ad gereklidir.")]
        [StringLength(50, ErrorMessage = "Ad 50 karakteri geçmemelidir.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Soyad gereklidir.")]
        [StringLength(50, ErrorMessage = "Soyad 50 karakteri geçmemelidir.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Telefon numarası gereklidir.")]
        [Range(0, 10, ErrorMessage = "Telefon numarası 10 karakterden az 20 karakteri geçmemelidir")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "E-posta gereklidir.")]
        [StringLength(50, ErrorMessage = "E-posta 50 karakteri geçmemelidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [StringLength(50, ErrorMessage = "Şifre 50 karakteri geçmemelidir.")]
        public string PasswordHash { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Adres bir 50 karakteri geçmemelidir.")]
        public string Address1 { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Adres iki 50 karakteri geçmemelidir.")]
        public string Address2 { get; set; } = string.Empty;
        [StringLength(50, ErrorMessage = "Posta Kodu 50 karakteri geçmemelidir.")]
        public string PostalCode { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Ülke 50 karakteri geçmemelidir.")]
        public string Country { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "Şehir 50 karakteri geçmemelidir.")]
        public string City { get; set; } = string.Empty;
    }
}
