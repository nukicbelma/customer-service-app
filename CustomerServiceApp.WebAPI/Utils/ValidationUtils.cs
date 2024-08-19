namespace CustomerServiceApp.WebAPI.Utils
{
    public static class ValidationUtils
    {
        public static bool IsNotNull(params object[] parameters)
        {
            foreach (var parameter in parameters)
            {
                if (parameter is string str && string.IsNullOrEmpty(str))
                {
                    return false;
                }

                if (parameter == null)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrEmpty(phoneNumber) && phoneNumber.All(char.IsDigit);
        }


    }
}
