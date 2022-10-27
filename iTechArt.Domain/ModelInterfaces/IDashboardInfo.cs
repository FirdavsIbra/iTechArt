namespace iTechArt.Domain.ModelInterfaces
{
    public interface IDashboardInfo
    {
        /// <summary>
        /// Count of pupils
        /// </summary>
        public int PupilCount { get; }

        /// <summary>
        /// Count of students
        /// </summary>
        public int StudentCount { get; }

        /// <summary>
        /// Count of groceries
        /// </summary>
        public int GroceryCount { get; }

        /// <summary>
        /// Count of polices
        /// </summary>
        public int PoliceCount { get; }

        /// <summary>
        /// Count of doctors
        /// </summary>
        public int DoctorCount { get; }

        /// <summary>
        /// Count of airports
        /// </summary>
        public int AirportCount { get; }
    }
}
