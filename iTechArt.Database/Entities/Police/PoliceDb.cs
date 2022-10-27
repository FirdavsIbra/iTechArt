namespace iTechArt.Database.Entities.Police
{
    public sealed class PoliceDb
    {
        /// <summary>
        /// Police Officers Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Police Officers Firstname
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Police Officers Lastname
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Police Officers email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Police Officers gender
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Police Officers address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Police Officers job title
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Police Officers salary
        /// </summary>
        public double Salary { get; set; }
    }
}
