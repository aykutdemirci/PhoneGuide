﻿namespace PhoneGuide.Application.Dto.Person
{
    public class DtoDisplayPersonWithContacts
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Company { get; set; }

        public object Contacts { get; set; }
    }
}
