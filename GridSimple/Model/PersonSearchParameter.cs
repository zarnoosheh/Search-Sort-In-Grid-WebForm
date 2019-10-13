using System;

namespace GridSimple.Model
{
    public class PersonSearchParameter
    {
        public string xFirstName { get; set; } = "";
        public string xLastName { get; set; } = "";
        public string xFatherName { get; set; } = "";
        public string xNationalID { get; set; } = "";
        public string xBirthCartPlace { get; set; } = "";
        public string xSortBy { get; set; }
        public string xSortType { get; set; }
        public int xPage { get; set; } = 1;
        public int xPageSize { get; set; } = 20;
    }
}