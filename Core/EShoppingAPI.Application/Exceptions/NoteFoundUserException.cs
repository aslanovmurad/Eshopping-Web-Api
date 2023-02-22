using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Application.Exceptions
{
    public class NoteFoundUserException : Exception
    {
        public NoteFoundUserException():base("username or password worning!")
        {
        }

        public NoteFoundUserException(string? message) : base(message)
        {
        }

        public NoteFoundUserException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
