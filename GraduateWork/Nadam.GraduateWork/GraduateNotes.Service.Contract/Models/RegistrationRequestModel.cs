namespace GraduateNotes.Service.Contract.Model
{
    public class RegistrationRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
    }
}
