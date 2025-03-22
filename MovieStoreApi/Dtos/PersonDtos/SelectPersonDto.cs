using System;

namespace MovieStoreApi.Dtos.PersonDto
{
    public class SelectPersonDto
    {
        public int Id { get; set; }

        public string FullName { get; set; } // Kullan�c�n�n tam ad�

        public string Email { get; set; } // Kullan�c�n�n e-posta adresi

        public bool EmailConfirmed { get; set; } // E-posta do�rulanm�� m�?

        public string? PhoneNumber { get; set; } // Kullan�c�n�n telefon numaras�

        public bool PhoneNumberConfirmed { get; set; } // Telefon numaras� do�rulanm�� m�?

        public DateTime BirthDate { get; set; } // Kullan�c�n�n do�um tarihi

        public string Address { get; set; } // Kullan�c�n�n adresi

        public bool IsActive { get; set; } // Kullan�c� aktif mi?

        public string? ProfilePicture { get; set; } // Kullan�c�n�n profil foto�raf� (URL)

        public string Gender { get; set; } // Kullan�c�n�n cinsiyeti (Enum yerine string d�nd�r�yoruz)

        public DateTime CreateDate { get; init; } // Kullan�c�n�n olu�turulma tarihi

        public string? RefreshToken { get; set; } // Kullan�c�n�n Refresh Token'�

        public DateTime? RefreshTokenExpiryTime { get; set; } // Refresh Token ge�erlilik s�resi
    }
}
