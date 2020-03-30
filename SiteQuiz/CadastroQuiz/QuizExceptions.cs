using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class InvalidEmailException : Exception
    {
        public InvalidEmailException()
            : base("Email não-utilizável")
        {
        }
        public InvalidEmailException(string email)
            : base(string.Format("O email {0} é não-utilizável", email))
        {
        }
    }
    public class EmailInUseException : Exception
    {
        public EmailInUseException()
            : base("Email já está em uso")
        {
        }
        public EmailInUseException(string email)
            : base(string.Format("O Email {0} já está em uso", email))
        {
        }
    }

    public class InvalidRMException : Exception
    {
        public InvalidRMException()
            : base("RM não-utilizável")
        {
        }
        public InvalidRMException(string rm)
            : base(string.Format("O RM {0} é não-utilizável", rm))
        {
        }
    }

    public class RMInUseException : Exception
    {
        public RMInUseException()
            : base("RM já está em uso")
        {
        }
        public RMInUseException(string rm)
            : base(string.Format("O RM {0} já está em uso", rm))
        {
        }
    }

    public class PassMismatchException : Exception
    {
        public PassMismatchException()
        : base("As duas senhas não são as mesmas.")
        { }
    }

    public class InvalidCaptchaException : Exception
    {
        public InvalidCaptchaException()
        : base("O Captcha é inválido.")
        { }
    }
    
    public class DatabaseInsertFail : Exception
    {
        public DatabaseInsertFail()
        : base("Erro ao inserir dados no banco de dados.")
        { }
    }