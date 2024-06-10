﻿namespace PhoneGuide.Application.Dto
{
    public sealed class DtoPerson
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Company { get; set; }

        public object Contacts {  get; set; }
    }
}
