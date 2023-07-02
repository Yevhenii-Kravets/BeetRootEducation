using System.Text.Json;

namespace Scheme
{
    public class Admin
    {
        private string Login { get; init; }
        private string Password { get; init; }
        private bool IsAdmin { get; init; } = false;

        private static Admin? _instance;

        private const string FileName = "Admin.json";
        private const string DefaultLogin = "admin";
        private const string DefaultPassword = "admin";

        public bool UserIsAdmin()
        {
            return IsAdmin;
        }

        public static Admin GetInstance(string Login = "", string Password = "")
        {
            if(_instance == null)
                _instance = new Admin(Login, Password);
            return _instance;
        }
        private Admin(string Login, string Password) 
        { 
            this.Login = Login;
            this.Password = Password;

            this.IsAdmin = DataIsTrue();
        }

        private bool DataIsTrue()
        {
            if (!File.Exists(FileName))
                using (StreamWriter writer = new StreamWriter(FileName))
                {
                    var data = new Data()
                    {
                        Login = DefaultLogin,
                        Password = DefaultPassword,
                    };
                    var json = JsonSerializer.Serialize(data);
                    writer.Write(json);
                }

            using (StreamReader reader = new StreamReader(FileName))
            {
                var json = reader.ReadToEnd();
                Data? data = JsonSerializer.Deserialize<Data>(json);

                if(data != null)
                    return data.Login == this.Login && data.Password == this.Password;
            }

            return false;
        }

        private class Data
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }
    }
}
