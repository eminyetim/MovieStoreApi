using System;

namespace MovieStoreApi.Dtos.PersonDto
{
    public class SelectPersonDto
    {
        public int Id { get; set; }

        public string FullName { get; set; } // Kullanýcýnýn tam adý

        public string Email { get; set; } // Kullanýcýnýn e-posta adresi

        public bool EmailConfirmed { get; set; } // E-posta doðrulanmýþ mý?

        public string? PhoneNumber { get; set; } // Kullanýcýnýn telefon numarasý

        public bool PhoneNumberConfirmed { get; set; } // Telefon numarasý doðrulanmýþ mý?

        public DateTime BirthDate { get; set; } // Kullanýcýnýn doðum tarihi

        public string Address { get; set; } // Kullanýcýnýn adresi

        public bool IsActive { get; set; } // Kullanýcý aktif mi?

        public string? ProfilePicture { get; set; } // Kullanýcýnýn profil fotoðrafý (URL)

        public string Gender { get; set; } // Kullanýcýnýn cinsiyeti (Enum yerine string döndürüyoruz)

        public DateTime CreateDate { get; init; } // Kullanýcýnýn oluþturulma tarihi

        public string? RefreshToken { get; set; } // Kullanýcýnýn Refresh Token'ý

        public DateTime? RefreshTokenExpiryTime { get; set; } // Refresh Token geçerlilik süresi
    }
}
